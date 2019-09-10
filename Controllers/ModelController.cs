using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository.Shared;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ModelController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ModelController(
            UnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetList(int startIndex, int pageSize)
        {
            // var  list = await _unitOfWork.Models.GetPageQueryableAsync(startIndex, pageSize, o => o.Id)
            //                 .Include(e => e.Carburant)
            //                 .Include(e => e.Transmission)
            //                 .Include(e => e.TypeVoiture)
            //                 .Include(e => e.Marque)
            //                 .ThenInclude(e => e.Country)
            //                 .ToListAsync();
            return Ok(new
            {
                list = await _unitOfWork.Models.GetPageQueryableAsync(startIndex, pageSize, o => o.Id)
                            // .Include(e => e.Carburant)
                            // .Include(e => e.Transmission)
                            // .Include(e => e.TypeVoiture)
                            .Include(e => e.Marque)
                            .ThenInclude(e => e.Country)
                            .ToListAsync(),
                count = await _unitOfWork.Models.CountAsync()
            });
        }

        [HttpGet("{startIndex}/{pageSize}")]
        public async Task<IActionResult> FilterList(int startIndex, int pageSize, string filter)
        {
            return Ok(new
            {
                list = await _unitOfWork.Models.GetPageFilteredAsync(startIndex, pageSize
                , o => o.Id, o => o.Id == filter)
                            .Include(e => e.Carburant)
                            .Include(e => e.Transmission)
                            .Include(e => e.TypeVoiture)
                            .Include(e => e.Marque)
                            .ThenInclude(e => e.Country)
                            .ToListAsync(),
                count = await _unitOfWork.Models.CountAsyncFlitred(o => o.Id == filter)
            });
        }

        [HttpGet("{idMarque}/{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetPageForModel(int idMarque, int startIndex, int pageSize)
        {
            return Ok(new
            {
                list = await _unitOfWork.Models.GetPageForModel(idMarque, startIndex, pageSize),
                count = await _unitOfWork.Models.CountAsyncFlitred(o => o.IdMarque == idMarque)
            });
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<IActionResult> Compare([FromRoute] string id1, [FromRoute] string id2)
        {
            return Ok(new
            {
                model1 = await _unitOfWork.Models.GetQueryableAsync(o => o.Id == id1)
                        .Include(e => e.Transmission)
                        .Include(e => e.Carburant)
                        .Include(e => e.TypeVoiture)
                        .Include(e => e.Marque)
                        .Include(e => e.ModelImgs)
                        .FirstOrDefaultAsync(),
                model2 = await _unitOfWork.Models.GetQueryableAsync(o => o.Id == id2)
                        .Include(e => e.Transmission)
                        .Include(e => e.Carburant)
                        .Include(e => e.TypeVoiture)
                        .Include(e => e.Marque)
                        .Include(e => e.ModelImgs)
                        .FirstOrDefaultAsync()
            });
        }

        [HttpGet("{idMarque}")]
        public async Task<IEnumerable<Model>> GetAllForModel([FromRoute] int idMarque)
        {
            return await _unitOfWork.Models.GetAllForModel(idMarque);
        }

        [HttpGet]
        public async Task<IEnumerable<Model>> Get()
        {
            return await _unitOfWork.Models.GetAllAsync(o => o.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Models.GetQueryableAsync(o => o.Id == id)
                        .Include(e => e.Transmission)
                        .Include(e => e.Carburant)
                        .Include(e => e.TypeVoiture)
                        .Include(e => e.Marque)
                        .Include(e => e.ModelImgs)
                        .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Models.Update(model);

            await _unitOfWork.Complete();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Models.AddAsync(model);

            int i = await _unitOfWork.Complete();
            return Ok(i);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.Models.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Models.Remove(model);
            int i = await _unitOfWork.Complete();

            return Ok(i);
        }

        private bool modelExists(string id)
        {
            var model = _unitOfWork.Models.Find(e => e.Id == id);

            if (model == null)
                return false;

            return true;
        }
    }
}
