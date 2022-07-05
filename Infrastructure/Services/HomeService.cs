using Application.Common.Interfaces;
using Application.Common.Persistence.Redis;
using Application.Common.Persistence.Sql;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class HomeService : IHomeService
    {
        private readonly IZoneRepository _zoneRepository;
        //private readonly IHomeRepository _homeRepository;

        public HomeService(IZoneRepository zoneRepository/*, IHomeRepository homeRepository*/)
        {
            _zoneRepository = zoneRepository;
            //_homeRepository = homeRepository;
        }

        // Method implement here

    }
}
