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
    public class StreamController : Controller
    {

        private IMapper _mapper;
        private IStreamRepository _repository;

        public StreamController(IMapper mapper, IStreamRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<StreamDto> GetAll()
        {
            var streamsList = _repository.GetAll();

            var streams = _mapper.Map<IEnumerable<Stream>, IEnumerable<StreamDto>>(streamsList);

            return streams;
        }

        [HttpGet("id",Name ="GetById")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);

            var stream = _mapper.Map<Stream, StreamDto>(item);

            if(stream == null)
            {
                return NotFound();
            }

            return new ObjectResult(stream);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]StreamDto stream)
        {
            var item = _mapper.Map<StreamDto, Stream>(stream);
            if(item == null)
            {
                return BadRequest();
            }

            _repository.Insert(item);
            return CreatedAtRoute("GetById", new { id = item.Id }, item
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody]StreamDto stream)
        {
            var item = _mapper.Map<StreamDto,Stream>(stream);
            if(item == null || stream.Id != id)
            {
                return BadRequest();
            }

            _repository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(StreamDto stream)
        {
            var item = _mapper.Map<StreamDto, Stream>(stream);
            if (item == null)
            {
                return BadRequest();
            }
            _repository.Delete(item);
            return new NoContentResult();
        }

    }
}
