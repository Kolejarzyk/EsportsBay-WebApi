using AutoMapper;
using EsportsBay.API.DataContracts;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Match, MatchDto>();
            CreateMap<MatchDto, Match>();
              
            CreateMap<Stream, StreamDto>();
            CreateMap<StreamDto, Stream>();
            CreateMap<TeamDto, Team>();
            CreateMap<Team, TeamDto>();
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<TournamentDto, Tournament>();
            CreateMap<Tournament, TournamentDto>();
        }
    }
}
