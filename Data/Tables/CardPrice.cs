using System.ComponentModel.DataAnnotations.Schema;

namespace JMPPAD.Data.Tables;

[Table("CardPrices")]
public class CardPrice
{
    public Guid CardId { get; set; }
    public string? PriceUsd { get; set; }
    public string? PriceEur { get; set; }
}