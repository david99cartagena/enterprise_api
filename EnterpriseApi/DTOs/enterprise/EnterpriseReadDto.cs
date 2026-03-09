using EnterpriseApi.DTOs.code;

namespace EnterpriseApi.DTOs.enterprise
{
    public class EnterpriseReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? Nit { get; set; }
        public long Gln { get; set; }
        public List<CodeReadDto> Codes { get; set; } = new();
    }
}
