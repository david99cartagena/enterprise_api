using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Code
{
    public int Id { get; set; }

    [Required]
    public int Owner { get; set; }
    
    [ForeignKey("Owner")]
    public Enterprise Enterprise { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Description { get; set; }
}
