using System.ComponentModel.DataAnnotations;

namespace EnterpriseApi.DTOs.enterprise
{
    public class CreateEnterpriseDto
    {
        [Required]
        public string Name { get; set; }
        public long? Nit { get; set; }

        [Required]
        public long Gln { get; set; }
    }
}
