using ProyectoBE.Data.Repository.Implementations;
using ProyectoBE.Data.Repository.Interfaces;
using ProyectoBE.Entities;
using ProyectoBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProyectoBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        public ContactController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOne(int Id)
        {
            return Ok(_contactRepository.GetAll().Where(x => x.Id == Id));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateAndUpdateContactDto createContactDto)
        {
            try
            {
                _contactRepository.Create(createContactDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("Created", createContactDto);
        }

        [HttpPut]
        public IActionResult UpdateContact(CreateAndUpdateContactDto dto)
        {
            try
            {
                _contactRepository.Update(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteContactById(int id)
        {
            try
            {
                if (User.Identity.Name == "Admin")
                {
                    _contactRepository.Delete(id);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }  
    }
}
