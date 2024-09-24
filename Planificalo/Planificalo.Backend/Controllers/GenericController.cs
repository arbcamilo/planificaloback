using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ActionResponse<IEnumerable<T>>>> GetAll()
        {
            var response = await _unitOfWork.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActionResponse<T>>> GetById(int id)
        {
            var response = await _unitOfWork.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ActionResponse<T>>> Add(T entity)
        {
            var response = await _unitOfWork.AddAsync(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActionResponse<T>>> Update(int id, T entity)
        {
            // Assuming the entity has a property named Id
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");
            if (idProperty != null)
            {
                idProperty.SetValue(entity, id);
            }

            var response = await _unitOfWork.UpdateAsync(entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActionResponse<T>>> Delete(int id)
        {
            var response = await _unitOfWork.DeleteAsync(id);
            return Ok(response);
        }
    }
}