// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.SignalR;
// using Microsoft.EntityFrameworkCore;
// using Repository.Shared;

// namespace mvc.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]/[action]")]
//     public class TypeUserController : ControllerBase
//     {
//         private readonly UnitOfWork _unitOfWork;
//         public TypeUserController(
//             UnitOfWork unitOfWork
//         )
//         {
//             _unitOfWork = unitOfWork;
//         }

//         [HttpGet("{startIndex}/{pageSize}")]
//         public async Task<IActionResult> GetList(int startIndex, int pageSize)
//         {
//             return Ok(new
//             {
//                 list = await _unitOfWork.TypeUsers.GetPageAsync(startIndex, pageSize, o => o.Id),
//                 count = await _unitOfWork.TypeUsers.CountAsync()
//             });
//         }

//         [HttpGet]
//         public async Task<IEnumerable<TypeUser>> Get()
//         {
//             return await _unitOfWork.TypeUsers.GetAllAsync(o => o.Id);
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> Get([FromRoute] int id)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var model = await _unitOfWork.TypeUsers.GetAsync(id);

//             if (model == null)
//             {
//                 return NotFound();
//             }

//             return Ok(model);
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TypeUser model)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (id != model.Id)
//             {
//                 return BadRequest();
//             }

//             _unitOfWork.TypeUsers.Update(model);

//             await _unitOfWork.Complete();
//             return NoContent();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Post([FromBody] TypeUser model)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             await _unitOfWork.TypeUsers.AddAsync(model);

//             int i = await _unitOfWork.Complete();
//             return Ok(i);
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete([FromRoute] int id)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var model = await _unitOfWork.TypeUsers.GetAsync(id);
//             if (model == null)
//             {
//                 return NotFound();
//             }

//             _unitOfWork.TypeUsers.Remove(model);
//             int i = await _unitOfWork.Complete();

//             return Ok(i);
//         }

//         private bool modelExists(int id)
//         {
//             var model = _unitOfWork.TypeUsers.Find(e => e.Id == id);

//             if (model == null)
//                 return false;

//             return true;
//         }
//     }
// }