using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("CubeContents")]
public class CubeContent
{
    [Key]
    public int Id { get; set; }
    public Guid CubeId { get; set; }
    public Guid DeckId { get; set; }
}