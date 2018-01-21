using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EsportsBay.API.DataContracts;
using EsportsBay.API.Model;
using EsportsBay.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using EsportsBay.API.Helper;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsportsBay.API.Controllers
{

    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private  IMapper _mapper;
        private  IUserRepository _repository;
        private readonly AppSettings _appSettings;

        public UserController(IUserRepository repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _repository.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<UserDto,User>(userDto);
            try
            {
                _repository.Create(user, userDto.Password);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            var usersList = _repository.GetAll();

            var users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(usersList);

            return users;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<User, UserDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDto user)
        {
            var model = _mapper.Map<UserDto, User>(user);
            model.Id = id;

            try
            {
                _repository.Update(model, user.Password);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(UserDto category)
        {
            var model = _mapper.Map<UserDto, User>(category);
            _repository.Delete(model);
            return new NoContentResult();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
