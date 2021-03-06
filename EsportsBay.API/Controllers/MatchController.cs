﻿using AutoMapper;
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
    public class MatchController : Controller
    {
        private IMapper _mapper;
        private IMatchRepository _repository;

        public MatchController(IMapper mapper, IMatchRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<MatchDto> GetAll()
        {
            var matchList = _repository.GetAll();

            var match = _mapper.Map<IEnumerable<Match>, IEnumerable<MatchDto>>(matchList);

            return match;
        }

        [HttpGet("{id:int}", Name = "GetMatch")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Match, MatchDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MatchDto item)
        {
            var model = _mapper.Map<MatchDto, Match>(item);
            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetMatch", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MatchDto match)
        {
            var model = _mapper.Map<MatchDto, Match>(match);
            if (match == null || match.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(MatchDto user)
        {
            var model = _mapper.Map<MatchDto, Match>(user);
            _repository.Delete(model);
            return new NoContentResult();
        }

        [HttpGet("{teamName}")]
        public IEnumerable<MatchDto> SearchMatch(string teamName)
        {
            var team = _repository.SearchByTeam(teamName);

            var searchedTeam = _mapper.Map<IEnumerable<Match>, IEnumerable<MatchDto>>(team);

            return searchedTeam;
        }

    }
}
