using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Information_Card.Core.Repositories.Base;
using Information_Card.Core.Entities.Base;

namespace Information_Card.Api.Controllers
{
    public interface IWebApiBase<TEntity>
        where TEntity : EntityBase
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<ActionResult<TEntity>> GetAsync(Guid id);
        Task<ActionResult> CreateAsync(TEntity item);
        Task<ActionResult> UpdateAsync(TEntity itemNew);
        Task<ActionResult> DeleteAsync(TEntity id);

    }

    public abstract class WebApiBase<TEntity, TController> : ControllerBase, IWebApiBase<TEntity>
        where TEntity : EntityBase
    {
        private readonly IRepository<TEntity> _repository;

        public WebApiBase(IRepository<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TEntity item)
        {
            try
            {
                await _repository.AddAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] TEntity item)
        {
            try
            {
                await _repository.DeleteAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                if (items.Count() <= 0)
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetAsync(Guid id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] TEntity itemNew)
        {
            try
            {
                await _repository.UpdateAsync(itemNew);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}