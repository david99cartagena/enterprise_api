public interface IEnterpriseService
{
    Task<IEnumerable<Enterprise>> GetAll();
    Task<Enterprise?> GetById(int id);
    Task<Enterprise?> GetByNit(long nit);
    Task<Enterprise> Create(Enterprise enterprise);
    Task<Enterprise?> Update(int id, Enterprise enterprise);
}
