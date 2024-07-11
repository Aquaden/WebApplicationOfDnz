using AutoMapper;
using System.Runtime;
using WebApplicationOfDnz.Data.Entities;
using WebApplicationOfDnz.DTO;

namespace WebApplicationOfDnz.Automapper
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO, Users>();
        }
    }
}
