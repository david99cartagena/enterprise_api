using AutoMapper;
using EnterpriseApi.DTOs.code;
using EnterpriseApi.DTOs.enterprise;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CodeController : ControllerBase
{
    private readonly ICodeService _service;
    private readonly IMapper _mapper;
    public CodeController(ICodeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var code = await _service.GetById(id);

        if (code == null)
            return NotFound();

        return Ok(_mapper.Map<CodeReadDto>(code));
    }

    [HttpGet("enterprise/{enterpriseId}")]
    public async Task<IActionResult> GetByEnterprise(int enterpriseId)
    {
        var codes = await _service.GetByEnterprise(enterpriseId);

        return Ok(_mapper.Map<List<CodeReadDto>>(codes));
    }

    [HttpGet("{id}/enterprise")]
    public async Task<IActionResult> GetEnterpriseOfCode(int id)
    {
        var enterprise = await _service.GetEnterpriseOfCode(id);

        if (enterprise == null)
            return NotFound();

        return Ok(_mapper.Map<EnterpriseReadDto>(enterprise));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCodeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var code = _mapper.Map<Code>(dto);

        var created = await _service.Create(code);

        if (created == null)
            return BadRequest("Enterprise does not exist.");

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            _mapper.Map<CodeReadDto>(created)
        );
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCodeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var code = _mapper.Map<Code>(dto);

        var updated = await _service.Update(id, code);

        if (updated == null)
            return NotFound();

        return Ok(_mapper.Map<CodeReadDto>(updated));
    }
}
