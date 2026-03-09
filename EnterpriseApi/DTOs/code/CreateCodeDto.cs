using System.ComponentModel.DataAnnotations;

namespace EnterpriseApi.DTOs.code
{
    public class CreateCodeDto
    {
        [Required]
        public int Owner { get; set; } // Id de la empresa

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
