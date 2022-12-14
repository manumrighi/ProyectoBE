using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoBE.Data.Repository.Interfaces;
using ProyectoBE.Models;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOneById(int Id)
        {
            try
            {
                return Ok(_userRepository.GetById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpPut]
        public IActionResult UpdateUser(CreateAndUpdateUserDto dto)
        {
            try
            {
                _userRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_userRepository.GetById(id).Name == "Admin")
                {
                    _userRepository.Delete(id);
                }
                else
                {
                    _userRepository.Archive(id);
                }
                return StatusCode(204);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
