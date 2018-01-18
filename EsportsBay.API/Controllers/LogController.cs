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
    public class LogController : Controller
    {
        private IMapper _mapper;
        private ILogRepository _repository;

        public LogController(IMapper mapper, ILogRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<LogDto> GetAll()
        {
            var logList = _repository.GetAll();

            var logs = _mapper.Map<IEnumerable<Log>, IEnumerable<LogDto>>(logList);

            return logs;
        }

        [HttpGet("{id}", Name = "GetLog")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Log, LogDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogDto item)
        {
            var model = _mapper.Map<LogDto, Log>(item);
            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetLog", new { id = model.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]LogDto log)
        {
            var model = _mapper.Map<LogDto, Log>(log);
            if (log == null || log.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(LogDto log)
        {
            var model = _mapper.Map<LogDto, Log>(log);
            _repository.Delete(model);
            return new NoContentResult();
        }
    }
}
