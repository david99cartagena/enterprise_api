using System.ComponentModel.DataAnnotations;
public class Enterprise
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public long? Nit { get; set; }

    [Required]
    public long Gln { get; set; }

    public ICollection<Code> Codes { get; set; } = new List<Code>();
}
