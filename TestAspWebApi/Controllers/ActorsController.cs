using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAspWebApi.DTOs.Actors;
using TestAspWebApi.Entities;

namespace TestAspWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/actors")]
    public class ActorsController : ControllerBase
    {
        private const string GetActorById = "GetActorById";

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> GetAll()
        {
            List<ActorEntity> actorsDb = await _context.Actors.ToListAsync();

            return _mapper.Map<List<ActorDTO>>(actorsDb);
        }

        [HttpGet("{id:int}", Name = GetActorById)]
        public async Task<ActionResult<ActorDTO>> GetById(int id)
        {
            ActorEntity actorDb = await _context.Actors.FindAsync(id);

            if (actorDb is null) { return NotFound(); }

            return _mapper.Map<ActorDTO>(actorDb);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ActorCreateNewDTO actorCreateNewDTO)
        {
            ActorEntity actorDb = _mapper.Map<ActorEntity>(actorCreateNewDTO);

            _context.Add(actorDb);
            await _context.SaveChangesAsync();

            ActorDTO actorDTO = _mapper.Map<ActorDTO>(actorDb);
            return new CreatedAtRouteResult(GetActorById, new { Id = actorDb.Id }, actorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateById(int id, [FromForm] ActorCreateNewDTO actorCreateNewDTO)
        {
            bool exist = await _context.Actors.AnyAsync(a => a.Id == id);
            if (!exist) { return NotFound(); }

            ActorEntity actorDb = _mapper.Map<ActorEntity>(actorCreateNewDTO);
            actorDb.Id = id;
            _context.Entry(actorDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            bool exist = await _context.Actors.AnyAsync(a => a.Id == id);
            if (!exist) { return NotFound(); }

            _context.Remove(new ActorEntity { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
