using Microsoft.EntityFrameworkCore;
public class EnterpriseService : IEnterpriseService
{
    private readonly AppDbContext _context;
    public EnterpriseService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Enterprise>> GetAll()
    {
        return await _context.Enterprises
            .Include(e => e.Codes)
            .ToListAsync();
    }
    public async Task<Enterprise?> GetById(int id)
    {
        return await _context.Enterprises
            .Include(e => e.Codes)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Enterprise?> GetByNit(long nit)
    {
        return await _context.Enterprises
            .Include(e => e.Codes)
            .FirstOrDefaultAsync(e => e.Nit == nit);
    }
    public async Task<Enterprise> Create(Enterprise enterprise)
    {
        var exists = await _context.Enterprises
            .AnyAsync(e => e.Nit == enterprise.Nit);

        if (exists)
            throw new Exception("Enterprise with same NIT already exists");

        _context.Enterprises.Add(enterprise);
        await _context.SaveChangesAsync();
        return enterprise;
    }
    public async Task<Enterprise?> Update(int id, Enterprise enterprise)
    {
        var existing = await _context.Enterprises.FindAsync(id);

        if (existing == null)
            return null;

        if (!string.IsNullOrWhiteSpace(enterprise.Name))
            existing.Name = enterprise.Name;

        if (enterprise.Nit != null)
            existing.Nit = enterprise.Nit;

        if (enterprise.Gln != 0)
            existing.Gln = enterprise.Gln;

        await _context.SaveChangesAsync();

        return existing;
    }
}
