using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("Decks")]
public class Deck
{
    /// <summary>
    ///     Deck ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     User that owns the deck
    /// </summary>
    public Guid? Owner { get; set; }

    /// <summary>
    ///     Name of the deck
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     Image on the front of the deck
    /// </summary>
    public byte[]? Image { get; set; }

    /// <summary>
    ///     Color identity of the deck, based on card contents.
    /// </summary>
    public string? ColorIdentity { get; set; }

    /// <summary>
    ///     DateTime when the Deck was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    ///     DateTime when the Deck was modified
    /// </summary>
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    ///     If this deck is an official WotC JMP deck
    /// </summary>
    public bool? IsOfficial { get; set; }
    
    public List<Card>? DeckContents { get; set; }
}