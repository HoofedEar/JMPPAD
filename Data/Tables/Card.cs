using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("Cards")]
public class Card
{
    /// <summary>
    /// Scryfall ID of the card object.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the card. If this card has multiple faces, this field will contain both names separated by ␣//␣.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Set code of the card
    /// </summary>
    public string? Set { get; set; }

    /// <summary>
    /// Full set name of the card
    /// </summary>
    public string? SetName { get; set; }

    /// <summary>
    /// Flavor text of this card
    /// </summary>
    public string? FlavorText { get; set; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string if the cost is absent.
    /// Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values.
    /// Multi-faced cards will report this value in card faces.
    /// </summary>
    public string? ManaCost { get; set; }

    /// <summary>
    /// The card’s converted mana cost. Be aware that some funny cards have fractional mana costs.
    /// </summary>
    public double? ManaValue { get; set; }

    public string? Rarity { get; set; }

    /// <summary>
    /// The Oracle text for this card, if any.
    /// </summary>
    public string? OracleText { get; set; }

    /// <summary>
    /// This card’s power, if any. Be aware that some cards have powers that are not numeric, such as *.
    /// </summary>
    public string? Power { get; set; }

    /// <summary>
    /// This card’s toughness, if any. Be aware that some cards have toughness that are not numeric, such as *.
    /// </summary>
    public string? Toughness { get; set; }

    /// <summary>
    /// The type line of this card.
    /// </summary>
    public string? TypeLine { get; set; }

    /// <summary>
    /// This card’s colors, if the overall card has colors defined by the rules.
    /// Otherwise the colors will be on the CardFaces objects.
    /// </summary>
    public string? Colors { get; set; }

    /// <summary>
    /// This card’s color identity.
    /// </summary>
    public string? ColorIdentity { get; set; }

    /// <summary>
    /// Has multiple faces?
    /// </summary>
    public bool? IsMultiFaced { get; set; }

    /// <summary>
    /// This loyalty if any. Be aware that some cards have loyalties that are not numeric, such as X.
    /// </summary>
    public string? Loyalty { get; set; }

    /// <summary>
    /// An object listing available imagery for this card.
    /// </summary>
    public string? ImageUri { get; set; }

    /// <summary>
    /// Art crop Uri of the Card
    /// </summary>
    public string? ArtCrop { get; set; }

    /// <summary>
    /// Artist for this card
    /// </summary>
    public string? Artist { get; set; }

    /// <summary>
    /// URL to view the card on Scryfall.com
    /// </summary>
    public string? Uri { get; set; }

    /// <summary>
    /// When this card was printed
    /// </summary>
    public string? ReleaseDate { get; set; }

    /// <summary>
    /// Collector Number for this card
    /// </summary>
    public string? CollectorNumber { get; set; }
    
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<Deck>? DeckContents { get; set; }
}