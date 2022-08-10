using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAspWebApi.DTOs;
using TestAspWebApi.Entities;

namespace TestAspWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/genres")]
    public class GenresController : ControllerBase
    {
        private const string GetGenreById = "GetGenreById";

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]  
        public async Task<ActionResult<List<GenreDTO>>> GetAllGenres()
        {
            List<GenreEntity> genresDb = await _context.Genres.ToListAsync();
            List<GenreDTO> genresDto = _mapper.Map<List<GenreDTO>>(genresDb);

            return genresDto;
        }

        [HttpGet("{id:int}", Name = GetGenreById)]
        public async Task<ActionResult<GenreDTO>> GetById(int id)
        {
            GenreEntity genreDb = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);

            if (genreDb is null)
            {
                return NotFound(); 
            }

            GenreDTO genreDto = _mapper.Map<GenreDTO>(genreDb);

            return genreDto;
        }

        [HttpPost]
        public async Task<ActionResult<GenreDTO>> CreateGenre([FromBody] GenreCreateNewDTO genreCreateNewDto)
        {
            GenreEntity genreDb = _mapper.Map<GenreEntity>(genreCreateNewDto);
            _context.Add(genreDb);
            await _context.SaveChangesAsync();

            GenreDTO genreDto = _mapper.Map<GenreDTO>(genreDb);

            return CreatedAtRoute(GetGenreById, new { Id = genreDto.Id }, genreDto);
        }

        [HttpPut("{id:int")]
        public async Task<ActionResult> UpdateGenre(int id, [FromBody] GenreCreateNewDTO genreCreateNewDTO)
        {
            bool exist = await _context.Genres.AnyAsync(g => g.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            GenreEntity genreDb = _mapper.Map<GenreEntity>(genreCreateNewDTO);
            genreDb.Id = id;
            _context.Entry(genreDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
