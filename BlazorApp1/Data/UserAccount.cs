using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data;
[Table("user_accounts")]

public class UserAccount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Username { get; set; }

    [MaxLength(50)]
    public string Password { get; set; }
    
    public bool isAdmin { get; set; }    
}