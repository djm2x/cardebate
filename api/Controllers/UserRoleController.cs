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
    public class UserRoleController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public UserRoleController(
            UnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{idUser}/{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetByUser(int idUser, int startIndex, int pageSize)
        {
            // var list = await _unitOfWork.UserRoles.GetPageByUser(idUser, startIndex, pageSize, o => o.IdUser);
            // var count = await _unitOfWork.UserRoles.CountAsync();
            return Ok(new
            {
                list = await _unitOfWork.UserRoles.GetPageForRole(idUser, startIndex, pageSize, o => o.IdUser),
                count = await _unitOfWork.UserRoles.CountAsync()
            });
        }

        [HttpGet]
        public async Task<IEnumerable<UserRole>> Get()
        {
            return await _unitOfWork.UserRoles.GetAllAsync(o => o.IdUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.UserRoles.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UserRole model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (id != model.IdUser && id != model.IdRole)
        //     {
        //         return BadRequest();
        //     }

        //     _unitOfWork.UserRoles.Update(model);

        //     await _unitOfWork.Complete();
        //     return NoContent();
        // }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.UserRoles.AddAsync(model);

            int i = await _unitOfWork.Complete();
            return Ok(i);
        }

        [HttpDelete("{idUser}/{idRole}")]
        public async Task<IActionResult> Delete([FromRoute] int idUser, [FromRoute] int idRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.UserRoles.GetAsync(idRole, idUser);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.UserRoles.Remove(model);
            int i = await _unitOfWork.Complete();

            return Ok(i);
        }

        private bool modelExists(int idU, int idR)
        {
            var model = _unitOfWork.UserRoles.Find(e => e.IdUser == idU && e.IdRole == idR);

            if (model == null)
                return false;

            return true;
        }
    }
}