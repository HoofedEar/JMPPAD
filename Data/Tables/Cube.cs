using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("Cubes")]
public class Cube
{
    public Guid Id { get; set; }
    public Guid Owner { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}