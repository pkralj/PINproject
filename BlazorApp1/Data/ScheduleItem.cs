using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlazorApp1.Data;
[Table("schedule_items")]

public class ScheduleItem
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; } 
    
    [NotNull]
    [MaxLength(100)]
    public string Location { get; set; }
    
    [MaxLength(30)]
    public string Title { get; set; }
    
    [MaxLength(30)]
    public string Host { get; set; }
    
    [MaxLength(100)]
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Time { get; set; }
    
    public int Occupancy { get; set; }
}