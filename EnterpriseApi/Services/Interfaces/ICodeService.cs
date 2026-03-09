public interface ICodeService
{
    Task<Code?> GetById(int id);
    Task<List<Code>> GetByEnterprise(int enterpriseId);
    Task<Enterprise?> GetEnterpriseOfCode(int codeId);
    Task<Code?> Create(Code code);
    Task<Code?> Update(int id, Code code);
}
