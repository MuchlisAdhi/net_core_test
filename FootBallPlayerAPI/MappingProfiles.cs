using AutoMapper;
using FootballPlayerAPI.Entities;
using FootballPlayerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballPlayerAPI
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, PlayerListViewModel>();
            CreateMap<PlayerListViewModel, Player>();
            CreateMap<CreatePlayerViewModel, Player>();
        }
    }
}
