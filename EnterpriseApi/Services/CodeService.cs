using Microsoft.EntityFrameworkCore;
public class CodeService : ICodeService
{
    private readonly AppDbContext _context;
    public CodeService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Code?> GetById(int id)
    {
        return await _context.Codes.FindAsync(id);
    }
    public async Task<List<Code>> GetByEnterprise(int enterpriseId)
    {
        return await _context.Codes
            .Where(c => c.Owner == enterpriseId)
            .ToListAsync();
    }
    public async Task<Enterprise?> GetEnterpriseOfCode(int codeId)
    {
        var code = await _context.Codes
            .Include(c => c.Enterprise)
            .FirstOrDefaultAsync(c => c.Id == codeId);

        return code?.Enterprise;
    }
    public async Task<Code?> Create(Code code)
    {
        var exists = await _context.Enterprises
            .AnyAsync(e => e.Id == code.Owner);

        if (!exists)
            return null;

        _context.Codes.Add(code);
        await _context.SaveChangesAsync();

        return code;
    }
    public async Task<Code?> Update(int id, Code code)
    {
        var existing = await _context.Codes.FindAsync(id);

        if (existing == null)
            return null;

        if (!string.IsNullOrWhiteSpace(code.Name))
            existing.Name = code.Name;

        if (!string.IsNullOrWhiteSpace(code.Description))
            existing.Description = code.Description;

        if (code.Owner != 0)
            existing.Owner = code.Owner;

        await _context.SaveChangesAsync();

        return existing;
    }
}
