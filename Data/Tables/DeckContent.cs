using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("DeckContents")]
public class DeckContent
{
    [Key]
    public int Id { get; set; }
    public Deck? Deck { get; set; }
    public Guid DeckId { get; set; }
    public Card? Card { get; set; }
    public Guid CardId { get; set; }
}