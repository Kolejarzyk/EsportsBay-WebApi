using AutoMapper;
using EsportsBay.API.DataContracts;
using EsportsBay.API.Model;
using EsportsBay.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private IMapper _mapper;
        private ITeamRepository _repository;

        public TeamController(ITeamRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<TeamDto> GetAll()
        {
            var matchList = _repository.GetAll();

            var match = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamDto>>(matchList);

            return match;
        }

        [HttpGet("{id}", Name = "GetByTeam")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Team, TeamDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TeamDto item)
        {
            var model = _mapper.Map<TeamDto, Team>(item);
            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetByTeam", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TeamDto team)
        {
            var model = _mapper.Map<TeamDto, Team>(team);
            if (team == null || team.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(TeamDto team)
        {
            var model = _mapper.Map<TeamDto, Team>(team);
            _repository.Delete(model);
            return new NoContentResult();
        }
    }
}
