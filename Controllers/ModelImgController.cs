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
    public class ModelImgController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ModelImgController(
            UnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{idModel}/{startIndex}/{pageSize}")]
        public async Task<IActionResult> GetPageForModelImg(string idModel, int startIndex, int pageSize)
        {
            // var list = await _unitOfWork.ModelImgs
            //             .GetPageForModelImg(idModel, startIndex, pageSize, o => o.Id);
            // var count = await _unitOfWork.ModelImgs.CountAsync();
            return Ok(new
            {
                list = await _unitOfWork.ModelImgs.GetPageForModelImg(idModel, startIndex, pageSize, o => o.Id),
                count = await _unitOfWork.ModelImgs.CountAsync()
            });
        }

        [HttpGet]
        public async Task<IEnumerable<ModelImg>> Get()
        {
            return await _unitOfWork.ModelImgs.GetAllAsync(o => o.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _unitOfWork.ModelImgs.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ModelImg model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ModelImgs.Update(model);

            await _unitOfWork.Complete();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelImg model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.ModelImgs.AddAsync(model);

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

            var model = await _unitOfWork.ModelImgs.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.ModelImgs.Remove(model);
            int i = await _unitOfWork.Complete();

            return Ok(i);
        }

        private bool modelExists(int id)
        {
            var model = _unitOfWork.ModelImgs.Find(e => e.Id == id);

            if (model == null)
                return false;

            return true;
        }
    }
}