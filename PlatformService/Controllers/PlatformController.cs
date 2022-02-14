using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        public PlatformController(IPlatformRepo repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("/all")]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetAllPlatforms()
        {
            var allPlatforms = _repo.GetAll();
            var allPlatformsMapped =_mapper.Map<IEnumerable<PlatformReadDto>>(allPlatforms);
            return Ok(allPlatformsMapped);
        }
        [HttpGet("/getById/{id}")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            var platform = _repo.Get(id);
            var platformMapped = _mapper.Map<PlatformReadDto>(platform);
            return Ok(platformMapped);
        }
        [HttpPost("/createPlatform")]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform([FromBody] PlatformCreateDto request)
        {
            var platform = _mapper.Map<Platform>(request);
            _repo.CreatePlatform(platform);
            _repo.SaveChanges();
            var mappedPlatform = _mapper.Map<PlatformReadDto>(platform);
            return Ok(mappedPlatform);
        }
    }
}
