using System.Text.Json;
using JMPPAD.Data.Scryfall;
using JMPPAD.Data.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JMPPAD.Data;

public static class Seeder
{
    public static async Task Start(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
        var userMgr = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
        var config = scope.ServiceProvider.GetService<IConfiguration>();
        if (config == null || context == null || userMgr == null)
        {
            Console.WriteLine("Unable to load app scope.");
            return;
        }

        var bulkDataPath = config.GetValue<string>("JMPPAD:ScryfallBulkDataPath");
        if (bulkDataPath == null)
        {
            Console.WriteLine("Unable to get bulk data path.");
            return;
        }

        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();

        if (context is not {Users: { }, Cards: { }, UserRoles: { }, CardFaces: { }})
            throw new Exception("Unable to verify database!");

        var invalid = new List<string>
        {
            "token", "planar", "scheme", "vanguard", "token", "double_faced_token", "emblem", "augment", "host",
            "art_series", "reversible_card"
        };

        var file = Directory.GetFiles(bulkDataPath);
        using var stream = new StreamReader(file[0]);
        var fileData = await stream.ReadToEndAsync();
        var cardData = JsonSerializer.Deserialize<List<ScryfallObject.CardObject>>(fileData);
        if (cardData == null)
        {
            Console.WriteLine("No card data loaded from JSON.");
            return;
        }

        foreach (var card in cardData)
        {
            // We don't want objects that aren't cards
            if (card.Layout != null && invalid.Contains(card.Layout))
            {
                continue;
            }

            // We don't want Arena/digital only cards
            if (card.SecurityStamp == "arena" || card.Digital == true)
            {
                continue;
            }

            // Create our new card entry for the database
            var cardObj = new Card
            {
                Id = new Guid(card.Id)
            };

            // Handle multi-face cards here
            if (card.CardFaces != null)
            {
                // We identify card faces by their shared card ID
                cardObj.IsMultiFaced = true;
                var frontSide = new CardFace {CardId = new Guid(card.Id)};
                var backSide = new CardFace {CardId = new Guid(card.Id)};

                // Front Side
                var frontData = card.CardFaces[0];
                frontSide.Name = frontData.Name;
                frontSide.Artist = frontData.Artist;
                frontSide.Loyalty = frontData.Loyalty;
                frontSide.TypeLine = frontData.TypeLine;
                frontSide.ManaCost = frontData.ManaCost;
                frontSide.Power = frontData.Power;
                frontSide.Toughness = frontData.Toughness;
                frontSide.ArtCrop = frontData.ImageUris?.ArtCrop;
                frontSide.Image = frontData.ImageUris?.Normal;
                frontSide.FlavorText = frontData.FlavorText;
                frontSide.Colors = ParseColors(frontData.Colors);
                frontSide.ColorIndicator = ParseColors(frontData.ColorIndicator);

                // Back Side
                var backData = card.CardFaces[1];
                backSide.Name = backData.Name;
                backSide.Artist = backData.Artist;
                backSide.Loyalty = backData.Loyalty;
                backSide.TypeLine = backData.TypeLine;
                backSide.ManaCost = backData.ManaCost;
                backSide.Power = backData.Power;
                backSide.Toughness = backData.Toughness;
                backSide.ArtCrop = backData.ImageUris?.ArtCrop;
                backSide.Image = backData.ImageUris?.Normal;
                backSide.FlavorText = backData.FlavorText;
                backSide.Colors = ParseColors(backData.Colors);
                backSide.ColorIndicator = ParseColors(backData.ColorIndicator);

                await context.CardFaces.AddAsync(frontSide);
                await context.CardFaces.AddAsync(backSide);
            }

            // Save all relevant card values
            cardObj.Name = card.Name;
            cardObj.Artist = card.Artist;
            cardObj.Colors = ParseColors(card.Colors);
            cardObj.Loyalty = card.Loyalty;
            cardObj.Power = card.Power;
            cardObj.Toughness = card.Toughness;
            cardObj.Rarity = card.Rarity;
            cardObj.Uri = card.ScryfallUri;
            cardObj.Set = card.Set;
            cardObj.SetName = card.SetName;
            cardObj.ColorIdentity = ParseColors(card.ColorIdentity);
            cardObj.ArtCrop = card.ImageUris?.ArtCrop;
            cardObj.ImageUri = card.ImageUris?.Normal;
            cardObj.FlavorText = card.FlavorText;
            cardObj.ManaCost = card.ManaCost;
            cardObj.ManaValue = card.Cmc;
            cardObj.OracleText = card.OracleText;
            cardObj.TypeLine = card.TypeLine;
            cardObj.ReleaseDate = card.ReleasedAt;
            cardObj.CollectorNumber = card.CollectorNumber;

            await context.Cards.AddAsync(cardObj);
        }

        // Create a Test User
        var userId = Guid.NewGuid();
        var testUser = new IdentityUser
        {
            Id = userId.ToString(),
            UserName = "AliceSmith",
            NormalizedEmail = "ALICESMITH",
            Email = "test@email.com",
            NormalizedUserName = "TEST@EMAIL.COM"
        };
        var result = await userMgr.CreateAsync(testUser, "Pass123$");
        if (!result.Succeeded) throw new Exception(result.Errors.First().Description);

        // Create demo Deck
        var deckId = new Guid("dc2cf69b-b189-4cbb-829d-dccf6b539a36");
        var deck = new Deck
        {
            Id = deckId,
            Owner = userId,
            Name = "Dragons",
            ColorIdentity = "R",
            CreatedAt = DateTime.Now
        };

        await context.Decks.AddAsync(deck);

        var cardIds = new List<string>
        {
            "F48B3F46-0E62-4F44-8064-857CD3040659",
            "8435C03C-B9A2-40FA-A979-879BD120A011",
            "41AC2C18-A26B-4683-B326-97F0E75B4F2A",
            "d99a9a7d-d9ca-4c11-80ab-e39d5943a315",
            "AC7BA3F5-3AD5-47E7-86C9-31954F015B91",
            "46F4AE10-A3DA-4D4F-8706-87CCB076C1F2",
            "069B3C69-EE4C-4FC9-981E-62DB77F9821D",
            "3AF09CFD-1DD1-45A8-869B-B21BCB03F7CE",
            "5E6F3C49-DBFA-4EAB-A561-656E74266834",
            "4E9A34A4-2F2C-4C9C-A8D4-73953B62E189",
            "7C337AF5-35BF-4A80-8CC0-BB9AF20305B3",
            "E48E23FE-F0ED-4C5A-B90B-30CF096A9D02",
            "5C3593AA-E33C-4482-A0BB-C843AC70A824",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA",
            "52C79D57-A8EB-427D-86AC-B203C0BB7CDA"
        };

        var cards = await context.Cards.ToListAsync();

        foreach (var id in cardIds)
        {
            var c = cards.FirstOrDefault(i => string.Equals(i.Id.ToString(), id, StringComparison.OrdinalIgnoreCase));
            if (c != null) await context.DeckContents.AddRangeAsync(new DeckContent {DeckId = deckId, CardId = c.Id});
            else
            {
                Console.WriteLine("Unable to find card.");
            }
        }

        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Parse a list of Colors from Scryfall JSON
    /// </summary>
    /// <param name="colors"></param>
    /// <returns>A string of Colors</returns>
    private static string ParseColors(IEnumerable<string>? colors)
    {
        if (colors == null)
            return "";
        var str = colors.Aggregate(string.Empty, (current, c) => current + $"{c}");
        str = str.TrimEnd();
        return str;
    }
}