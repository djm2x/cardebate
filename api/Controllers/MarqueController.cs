using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Shared;

namespace mvc.Controllers
{
    // [Authorize(Roles = "1")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MarqueController : ControllerBase
    {
        // private IHubContext<MarqueHub, IMarqueHub> _hubContext;
        private readonly UnitOfWork _unitOfWork;
        public MarqueController(
            UnitOfWork unitOfWork
            // , IHubContext<MarqueHub, IMarqueHub> hubContext
        )
        {
            _unitOfWork = unitOfWork;
            // _hubContext = hubContext;
        }

        [HttpGet("{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetList(int startIndex, int pageSize)
        {
            var list = await _unitOfWork.Marques.GetPageQueryableAsync(startIndex, pageSize, o => o.Id)
                            // .Include(e => e.Country)
                            .Select(e => new {
                                e.Id,
                                e.Name,
                                e.Country
                            })
                            .ToListAsync();
            var count = await _unitOfWork.Marques.CountAsync();
            return Ok(new
            {
                list = await _unitOfWork.Marques.GetPageQueryableAsync(startIndex, pageSize, o => o.Id)
                            // .Include(e => e.Country)
                            .Select(e => new {
                                e.Id,
                                e.Name,
                                e.ImageUrl,
                                e.Country
                            })
                            .ToListAsync(),
                count = await _unitOfWork.Marques.CountAsync()
            });
        }

        // GET: api/models
        [HttpGet]
        public async Task<IEnumerable<Marque>> Get()
        {
            return await _unitOfWork.Marques.GetAllAsync(o => o.Id);
        }

        // GET: api/models/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Marques.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/models/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Marque model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Marques.Update(model);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!modelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/models
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Marque model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Marques.AddAsync(model);

            try
            {
                await _unitOfWork.Complete();
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            // return CreatedAtAction("model", new { id = model.Id }, model);
        }

        // DELETE: api/models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Marques.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Marques.Remove(model);
            await _unitOfWork.Complete();

            return Ok(model);
        }

        private bool modelExists(int id)
        {
            var model = _unitOfWork.Marques.Find(e => e.Id == id);

            if (model == null)
                return false;

            return true;
        }
    }
}