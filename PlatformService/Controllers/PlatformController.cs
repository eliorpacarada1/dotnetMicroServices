using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        public PlatformController(IPlatformRepo repo, IMapper mapper,ICommandDataClient commandDataClient)
        {
            _repo = repo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetAllPlatforms()
        {
            var allPlatforms = await _repo.GetAll();
            var allPlatformsMapped =_mapper.Map<IEnumerable<PlatformReadDto>>(allPlatforms);
            return Ok(allPlatformsMapped);
        }
        [HttpGet("/getbyid/{id}")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            var platform = await _repo.Get(id);
            var platformMapped = _mapper.Map<PlatformReadDto>(platform);
            return Ok(platformMapped);
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform([FromBody] PlatformCreateDto request)
        {
            var platform = _mapper.Map<Platform>(request);
            await _repo.CreatePlatform(platform);
            await _repo.SaveChanges();
            var mappedPlatform = _mapper.Map<PlatformReadDto>(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(mappedPlatform);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(mappedPlatform);
        }
    }
}
