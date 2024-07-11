using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using WebApplicationOfDnz.Data;
using WebApplicationOfDnz.Data.Entities;
using WebApplicationOfDnz.DTO;

namespace WebApplicationOfDnz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper)
        {
            _mapper = mapper; 
        }


        [HttpPost("PostUsers")]
        public IActionResult PostUsers(UsersDTO us)
        {
            
            Users user = _mapper.Map<Users>(us);    
            using(var context = new AppDbContext())
            {
                context.Users2.Add(user);
            }


            return Ok();
            
            
            
        }

        [HttpGet("GetUsers")]
        public List<Users> GetUsers()
        {
            using(var context = new AppDbContext())
            {
                return context.Users2.ToList();
            }
            
            
        }

        [HttpPut("PutUsers")]
        public bool Putusers(int id, UsersDTO u)
        {
            using (var context = new AppDbContext())
            {
                var data = context.Users2.Where(predicate => predicate.Id == id).FirstOrDefault();
                data.Surname = u.Surname;
                data.Name = u.Name;
                context.Users2.Update(data);
            }
            return true;
        }

        [HttpDelete("DeletUsers")]
        public bool DeleteUsers(int id)
        {
            using(var context = new AppDbContext())
            {
                var data = context.Users2.Where(predicate => predicate.Id == id).FirstOrDefault();
                context.Users2.Remove(data);
            }
            return true;
        }

    }
}
