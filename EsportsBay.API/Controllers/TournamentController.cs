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
    public class TournamentController : Controller
    {
        private IMapper _mapper;
        private ITournamentRepository _repository;

        public TournamentController(IMapper mapper, ITournamentRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<TournamentDto> GetAll()
        {
            var logList = _repository.GetAll();

            var logs = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentDto>>(logList);

            return logs;
        }

        [HttpGet("{id}", Name = "GetByTournament")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Tournament, TournamentDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TournamentDto item)
        {
            var model = _mapper.Map<TournamentDto, Tournament>(item);
            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetByTournament", new { id = model.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TournamentDto tournament)
        {
            var model = _mapper.Map<TournamentDto, Tournament>(tournament);
            if (tournament == null || tournament.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(TournamentDto log)
        {
            var model = _mapper.Map<TournamentDto, Tournament>(log);
            _repository.Delete(model);
            return new NoContentResult();
        }
    }
}
