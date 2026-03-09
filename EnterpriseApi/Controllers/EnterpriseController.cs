using AutoMapper;
using EnterpriseApi.DTOs.enterprise;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EnterpriseController : ControllerBase
{
    private readonly IEnterpriseService _service;
    private readonly IMapper _mapper;

    public EnterpriseController(IEnterpriseService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var enterprises = await _service.GetAll();
        var result = _mapper.Map<List<EnterpriseReadDto>>(enterprises);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var enterprise = await _service.GetById(id);

        if (enterprise == null)
            return NotFound();

        return Ok(_mapper.Map<EnterpriseReadDto>(enterprise));
    }

    [HttpGet("nit/{nit}")]
    public async Task<IActionResult> GetByNit(long nit)
    {
        var enterprise = await _service.GetByNit(nit);

        if (enterprise == null)
            return NotFound();

        return Ok(_mapper.Map<EnterpriseReadDto>(enterprise));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEnterpriseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var enterprise = _mapper.Map<Enterprise>(dto);

        var created = await _service.Create(enterprise);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            _mapper.Map<EnterpriseReadDto>(created)
        );
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateEnterpriseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var enterprise = _mapper.Map<Enterprise>(dto);

        var updated = await _service.Update(id, enterprise);

        if (updated == null)
            return NotFound();

        return Ok(_mapper.Map<EnterpriseReadDto>(updated));
    }
}
