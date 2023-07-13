using AutoMapper;
using GazpromTest.DTO;
using GazpromTest.Models;
using GazpromTest.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GazpromTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WellController : ControllerBase
    {
        private readonly IWellRepository _wellRepository;
        private readonly IMapper _mapper;

        public WellController(IWellRepository wellRepository, IMapper mapper)
        {
            _wellRepository = wellRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<WellDto> GetById(long id)
        {
            var well = _wellRepository.GetById(id);
            if (well == null)
            {
                return NotFound();
            }

            var wellDto = _mapper.Map<WellDto>(well);
            return Ok(wellDto);
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<WellDto>> GetAll()
        {
            var wells = _wellRepository.GetAll();
            var wellDtos = _mapper.Map<IEnumerable<WellDto>>(wells);
            return Ok(wellDtos);
        }

        [HttpPost]
        public ActionResult Add(WellDto wellDto)
        {
            var well = _mapper.Map<Well>(wellDto);
            _wellRepository.Add(well);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, WellDto wellDto)
        {
            var well = _wellRepository.GetById(id);
            if (well == null)
            {
                return NotFound();
            }

            well.Name = wellDto.Name;
            _wellRepository.Update(well);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var well = _wellRepository.GetById(id);
            if (well == null)
            {
                return NotFound();
            }

            _wellRepository.Delete(id);
            return Ok();
        }
    }
}
