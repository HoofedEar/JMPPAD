using JMPPAD.Data;
using JMPPAD.Data.Tables;
using JMPPAD.Data.Tables.UserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JMPPAD.Helpers;

public class DeckHelpers(ApplicationDbContext context, IMemoryCache cache, ManaHelpers manaHelpers)
{
    public async Task<Deck> CheckDeckId(string deckId)
    {
        try
        {
            var deckGuid = new Guid(deckId);
            var deck = await context.Decks
                .Where(i => i.Id == deckGuid)
                .FirstOrDefaultAsync();

            return deck ?? new Deck { Id = Guid.Empty };
        }
        catch
        {
            return new Deck { Id = Guid.Empty };
        }
    }

    public async Task<List<Card>> GetDeckList(string deckId)
    {
        var result = await context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .Select(d => d.DeckContents)
            .FirstOrDefaultAsync();

        return result ?? new List<Card>();
    }

    public async Task<bool> AddCardToDeck(Deck deck, string cardName)
    {
        var card = await context.Cards
            .Where(c => c.Name != null && c.Name.ToUpper() == cardName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();

        if (card == Guid.Empty)
        {
            return false;
        }

        var addition = new DeckContent
        {
            CardId = card,
            DeckId = deck.Id
        };

        await context.DeckContents.AddAsync(addition);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveCardFromDeck(Deck deck, Card card)
    {
        var value = await context.DeckContents
            .Where(d => d.Deck == deck)
            .Where(c => c.Card == card)
            .FirstOrDefaultAsync();

        if (value == null) return false;

        context.DeckContents.Remove(value);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Card>> GetCardListNew(string deckId)
    {
        var result = await context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .Select(d => d.DeckContents)
            .FirstOrDefaultAsync();

        return result ?? new List<Card>();
    }

    public async Task<string[]> GetCardNames()
    {
        if (cache.TryGetValue("CardName", out string[]? cardNames)) return cardNames!;

        cardNames = await context.Cards
            .Select(i => i.Name!.ToString())
            .Distinct()
            .ToArrayAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.NeverRemove);

        cache.Set("CardName", cardNames, cacheEntryOptions);

        return cardNames;
    }

    public async Task<Card[]?> GetCardPrintings(Card card)
    {
        if (cache.TryGetValue($"{card.Name!}", out Card[]? cardPrintings)) return cardPrintings!;

        cardPrintings = await context.Cards
            .Where(i => i.Name == card.Name)
            .OrderBy(i => i.ReleaseDate)
            .ToArrayAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.NeverRemove);

        cache.Set($"{card.Name!}", cardPrintings, cacheEntryOptions);

        return cardPrintings;
    }

    public async Task<List<Deck>> GetUserDecks(string userId)
    {
        var decksList = await context.Decks
            .Where(d => d.Owner == new Guid(userId))
            .ToListAsync();

        return decksList.Any() ? decksList : new List<Deck>();
    }

    public async Task CreateNewDeck(string userId, string identity, string name, string theme)
    {
        var newDeck = new Deck
        {
            Owner = new Guid(userId),
            Name = name,
            ColorIdentity = identity,
            CreatedAt = DateTime.Now,
            IsOfficial = false
        };

        await context.Decks.AddAsync(newDeck);
        await context.SaveChangesAsync();
    }

    public async Task DeleteDeck(string deckId)
    {
        var deck = await context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .FirstOrDefaultAsync();

        if (deck == null) return;

        context.Decks.Remove(deck);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDeck(Deck deck, List<Card> deckList)
    {
        var entity = await context.Decks.Where(i => i == deck).FirstOrDefaultAsync();
        if (entity != null) entity.DeckContents = deckList;
        await context.SaveChangesAsync();
    }

    public async Task UpdateCardInDeck(Deck deck, Card oldCard, Card newCard)
    {
        var content = await context.DeckContents
            .Where(i => i.Deck == deck)
            .Include(deckContent => deckContent.Card)
            .ToListAsync();

        var obj = content.FirstOrDefault(obj => obj.Card == oldCard);
        if (obj == null) return;

        obj.Card = newCard;
        await context.SaveChangesAsync();
    }

    public async Task UpdateDeckName(Deck deck, string name)
    {
        var obj = await context.Decks
            .Where(i => i == deck)
            .Include(d => d.DeckContents)
            .FirstOrDefaultAsync();

        if (obj == null) return;

        obj.Name = name;

        if (obj.DeckContents != null)
            obj.ColorIdentity = string.Join("", manaHelpers.DeckListColorParse(obj.DeckContents));

        await context.SaveChangesAsync();
    }

    public async Task<bool> AddDeckToFavorites(Deck deck, string userId)
    {
        var obj = await context.Decks
            .Where(i => i == deck)
            .FirstOrDefaultAsync();

        if (obj == null) return false;

        // Check if deck is already favorited
        var check = await context.Favorites
            .Where(i => i.DeckId == obj.Id && i.UserId == userId)
            .FirstOrDefaultAsync();
        if (check != null) return false;

        var favorite = new Favorites
        {
            DeckId = obj.Id,
            UserId = userId
        };

        await context.Favorites.AddAsync(favorite);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckDeckFavorite(Deck deck, string userId)
    {
        var obj = await context.Decks
            .Where(i => i == deck)
            .FirstOrDefaultAsync();

        if (obj == null) return false;

        var favorite = await context.Favorites
            .Where(i => i.DeckId == obj.Id && i.UserId == userId)
            .FirstOrDefaultAsync();

        return favorite != null;
    }

    public async Task<bool> RemoveDeckFromFavorites(Deck deck, string userId)
    {
        var obj = await context.Decks
            .Where(i => i == deck)
            .FirstOrDefaultAsync();

        if (obj == null) return false;

        var favorite = await context.Favorites
            .Where(i => i.DeckId == obj.Id && i.UserId == userId)
            .FirstOrDefaultAsync();

        if (favorite == null) return false;

        context.Favorites.Remove(favorite);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Deck?>> GetFavoriteDecks(string userId)
    {
        var decks = await context.Favorites
            .Where(i => i.UserId == userId)
            .Include(i => i.Deck)
            .Select(i => i.Deck)
            .ToListAsync();

        return decks.Count != 0 ? decks : [];
    }
}