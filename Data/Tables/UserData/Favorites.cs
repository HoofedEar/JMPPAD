using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace JMPPAD.Data.Tables.UserData;

public class Favorites
{
    public Guid Id { get; set; }

    /// <summary>
    /// User that favorited the deck
    /// </summary>
    [ForeignKey("User")]
    public string UserId { get; set; } = null!;
    public IdentityUser? User { get; set; }
    
    /// <summary>
    /// Deck that was favorited
    /// </summary>
    [ForeignKey("Deck")] 
    public Guid DeckId { get; set; }
    public Deck? Deck { get; set; }
}