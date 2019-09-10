using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Shared;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public UserController(
            UnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetList(int startIndex, int pageSize)
        {
            return Ok(new
            {
                list = await _unitOfWork.Users.GetPageQueryableAsync(startIndex, pageSize, o => o.Id)
                            // .Include(e => e.TypeUser)
                            .Include(e => e.UserRoles)
                            .ThenInclude(e => e.Role)
                            .ToListAsync(),
                count = await _unitOfWork.Users.CountAsync()
            });
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _unitOfWork.Users.GetAllAsync(o => o.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Users.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Users.Update(model);

            await _unitOfWork.Complete();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dynamic obj = await _unitOfWork.Users.LogIn(model.Email, model.Password);

            if (obj == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new {user = obj.user, token = obj.token, idRole = obj.idRole});
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Users.SignIn(model);

            await _unitOfWork.Complete();
            model.UserRoles = null;
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Users.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Users.Remove(model);
            int i = await _unitOfWork.Complete();

            return Ok(i);
        }

        private bool modelExists(int id)
        {
            var model = _unitOfWork.Users.Find(e => e.Id == id);

            if (model == null)
                return false;

            return true;
        }
    }
}

public class UserVM
{
    public string Email { get; set; }
    public string Password { get; set; }
}