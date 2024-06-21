using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("CardFaces")]
public class CardFace
{
    /// <summary>
    ///     Id of the Face
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Card Id that this face is associated with.
    /// </summary>
    [ForeignKey("Card")]
    public Guid CardId { get; set; }

    /// <summary>
    ///     Artist of the card face
    /// </summary>
    public string? Artist { get; set; }

    /// <summary>
    ///     Art Crop of the card face
    /// </summary>
    public string? ArtCrop { get; set; }

    /// <summary>
    ///     Flavor text of the card face
    /// </summary>
    public string? FlavorText { get; set; }

    /// <summary>
    ///     This face’s colors, if the game defines colors for the individual face of this card.
    /// </summary>
    public string? Colors { get; set; }

    /// <summary>
    ///     The colors in this face’s color indicator, if any.
    /// </summary>
    public string? ColorIndicator { get; set; }

    /// <summary>
    ///     An object providing URIs to imagery for this face, if this is a double-sided card.
    ///     If this card is not double-sided, then the image_uris property will be part of the parent object instead.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    ///     This face’s loyalty, if any.
    /// </summary>
    public string? Loyalty { get; set; }

    /// <summary>
    ///     The mana cost for this face.
    ///     This value will be any empty string "" if the cost is absent.
    ///     Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values.
    /// </summary>
    public string? ManaCost { get; set; }

    /// <summary>
    ///     The name of this particular face.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The Oracle text for this face, if any.
    /// </summary>
    public string? OracleText { get; set; }

    /// <summary>
    ///     This face’s power, if any. Be aware that some cards have powers that are not numeric, such as *.
    /// </summary>
    public string? Power { get; set; }

    /// <summary>
    ///     This face’s toughness, if any.
    /// </summary>
    public string? Toughness { get; set; }

    /// <summary>
    ///     The type line of this particular face, if the card is reversible.
    /// </summary>
    public string? TypeLine { get; set; }
}