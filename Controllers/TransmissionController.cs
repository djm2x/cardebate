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
    public class TransmissionController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public TransmissionController(
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
                list = await _unitOfWork.Transmissions.GetPageAsync(startIndex, pageSize, o => o.Id),
                count = await _unitOfWork.Transmissions.CountAsync()
            });
        }

        [HttpGet]
        public async Task<IEnumerable<Transmission>> Get()
        {
            return await _unitOfWork.Transmissions.GetAllAsync(o => o.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Transmissions.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Transmission model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Transmissions.Update(model);

            await _unitOfWork.Complete();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transmission model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Transmissions.AddAsync(model);

            int i = await _unitOfWork.Complete();
            return Ok(i);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Transmissions.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Transmissions.Remove(model);
            int i = await _unitOfWork.Complete();

            return Ok(i);
        }

        private bool modelExists(int id)
        {
            var model = _unitOfWork.Transmissions.Find(e => e.Id == id);

            if (model == null)
                return false;

            return true;
        }
    }
}