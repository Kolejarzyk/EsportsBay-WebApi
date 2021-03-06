﻿using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface IMatchRepository : IRepository<Match>
    {

        IEnumerable<Match> SearchByTeam(string teamName);
    }
}
