using JMPPAD.Data;
using JMPPAD.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JMPPAD.Helpers;

public class DeckHelpers
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;

    public DeckHelpers(ApplicationDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<Deck> CheckDeckId(string deckId)
    {
        try
        {
            var deckGuid = new Guid(deckId);
            var deck = await _context.Decks
                .Where(i => i.Id == deckGuid)
                .FirstOrDefaultAsync();

            return deck ?? new Deck {Id = Guid.Empty};
        }
        catch
        {
            return new Deck {Id = Guid.Empty};
        }
    }

    public async Task<List<Card>> GetDeckList(string deckId)
    {
        var result = await _context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .Select(d => d.DeckContents)
            .FirstOrDefaultAsync();

        return result ?? new List<Card>();
    }

    public async Task<bool> AddCardToDeck(Deck deck, string cardName)
    {
        var card = await _context.Cards
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

        await _context.DeckContents.AddAsync(addition);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveCardFromDeck(Deck deck, Card card)
    {
        var value = await _context.DeckContents
            .Where(d => d.Deck == deck)
            .Where(c => c.Card == card)
            .FirstOrDefaultAsync();

        if (value == null) return false;

        _context.DeckContents.Remove(value);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Card>> GetCardListNew(string deckId)
    {
        var result = await _context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .Select(d => d.DeckContents)
            .FirstOrDefaultAsync();

        return result ?? new List<Card>();
    }

    public async Task<string[]> GetCardNames()
    {
        if (_cache.TryGetValue("CardName", out string[]? cardNames)) return cardNames!;

        cardNames = await _context.Cards
            .Select(i => i.Name!.ToString())
            .Distinct()
            .ToArrayAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.NeverRemove);

        _cache.Set("CardName", cardNames, cacheEntryOptions);

        return cardNames;
    }

    public async Task<Card[]?> GetCardPrintings(Card card)
    {
        if (_cache.TryGetValue($"{card.Name!}", out Card[]? cardPrintings)) return cardPrintings!;

        cardPrintings = await _context.Cards
            .Where(i => i.Name == card.Name)
            .OrderBy(i => i.ReleaseDate)
            .ToArrayAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.NeverRemove);

        _cache.Set($"{card.Name!}", cardPrintings, cacheEntryOptions);

        return cardPrintings;
    }

    public async Task<List<Deck>> GetUserDecks(string userId)
    {
        var decksList = await _context.Decks
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

        await _context.Decks.AddAsync(newDeck);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDeck(string deckId)
    {
        var deck = await _context.Decks
            .Where(d => d.Id == new Guid(deckId))
            .FirstOrDefaultAsync();

        if (deck != null)
        {
            _context.Decks.Remove(deck);
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateDeck(Deck deck, List<Card> deckList)
    {
        var entity = await _context.Decks.Where(i => i == deck).FirstOrDefaultAsync();
        if (entity != null) entity.DeckContents = deckList;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCardInDeck(Deck deck, Card oldCard, Card newCard)
    {
        var content = await _context.DeckContents
            .Where(i => i.Deck == deck)
            .ToListAsync();

        var obj = content.FirstOrDefault(obj => obj.Card == oldCard);
        if (obj != null)
        {
            obj.Card = newCard;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateDeckName(Deck deck, string name)
    {
        var obj = await _context.Decks
            .Where(i => i == deck)
            .FirstOrDefaultAsync();

        if (obj != null)
        {
            obj.Name = name;
        }

        await _context.SaveChangesAsync();
    }
}