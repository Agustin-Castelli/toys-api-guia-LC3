﻿using Data.DTOs;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            try
            {
                var response = _service.GetUsers();
                if(response == null)
                {
                    return BadRequest();
                }

                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo GetUsers: {exe.Message}");
                return BadRequest(exe.Message);
            }
        }

        [HttpGet("getuserbyid")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            try
            {
                var response = _service.GetUserById(id);
                if(response == null)
                {
                    return BadRequest();
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo GetUserById: {exe.Message}");
                return BadRequest(exe.Message );
            }
        }

        [HttpPost]
        public ActionResult<UserDTO> AddUser([FromBody] UserViewModel user)
        {
            try
            {
                var response = _service.AddUser(user);
                if(response == null)
                {
                    return BadRequest();
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo AddUser: {exe.Message}");
                return BadRequest(exe.Message);
            }
        }

        [HttpPut]
        public ActionResult<UserDTO> UpdateUser(UserViewModel user)
        {
            try
            {
                var response = _service.UpdateUser(user);
                if (response == null)
                {
                    return BadRequest();
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo UpdateUser: {exe.Message}");
                return BadRequest(exe.Message);
            }
        }

        [HttpDelete]
        public ActionResult<UserDTO> DeleteUser(int id)
        {
            try
            {
                _service.DeleteUser(id);

                return Ok();
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo DeleteUser: {exe.Message}");
                return BadRequest(exe.Message);
            }
        }

        [HttpPatch]
        public ActionResult<UserDTO> RecoverUser(int id)
        {
            try
            {
                _service.RecoverUser(id);
                return Ok();
            }
            catch (Exception exe)
            {
                _logger.LogError($"Error en UserController, metodo RecoverUser: {exe.Message}");
                return BadRequest(exe.Message);
            }
        }
    }
}
