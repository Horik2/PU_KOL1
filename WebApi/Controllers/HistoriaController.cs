using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriaController : ControllerBase
    {
        private readonly IHistoriaService _service;
        private readonly IHistoriaProcedureService _procedureService;

        public HistoriaController(IHistoriaService service, IHistoriaProcedureService procedureService)
        {
            _service = service;
            _procedureService = procedureService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoriaDto>>> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _service.GetPagedAsync(page, pageSize));
        }

        [HttpGet("procedure")]
        public async Task<ActionResult<List<HistoriaDto>>> GetPagedByProcedure([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await _procedureService.GetPagedAsync(page, pageSize));
        }
    }
}
