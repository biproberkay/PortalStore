global using PortalStore.Domain.Contracts; //precede all non global
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalStore.Application;
using PortalStore.Shared.Wrappers;

namespace PortalStore.Api.Controllers
{
    /// <summary>
    /// this is a custom abstract generic controller. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCore"></typeparam>
    /// <typeparam name="TId"></typeparam>
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]//https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/conventions?view=aspnetcore-7.0#apply-web-api-conventions 
    [ApiController]
    public abstract class BaseController<T, TReadDto, TEditDto, TCreateDto, TDeleteDto, TId> : ControllerBase
        where T : class, IBaseEntity<TId>
        where TReadDto : IReadDto<TId>
        where TEditDto : IEditDto<TId>
        where TCreateDto : ICreateDto
        where TDeleteDto : IDeleteDto<TId>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T, TId> _repository;
        private readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T, TId>();
            _mapper = mapper;
        }
        // GET: api/<BaseController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _unitOfWork.GetRepository<T, TId>().Entities.ToList();
            var coreData = _mapper.Map<List<T>, List<TReadDto>>(data);
            var result = CustomResult<List<TReadDto>>.Success(coreData);
            return Ok(result);
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(TId id)
        {
            var data = await _repository.GetByIdAsync(id);
            var coreData = _mapper.Map<T, TReadDto>(data);
            return Ok(CustomResult<TReadDto>.Success(coreData));
        }

        // POST api/<BaseController>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TCreateDto tCore, CancellationToken cancellationToken)
        {
            var tData = _mapper.Map<TCreateDto, T>(tCore);
            var insertedTData = await _repository.AddAsync(tData); 
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(CustomResult<T>.Success(insertedTData, $"new {nameof(T)} entity have been inserted to db successfull"));
        }

        // PUT api/<BaseController>/5
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TEditDto tCore, CancellationToken cancellationToken)
        {
            var tData = _mapper.Map<TEditDto, T>(tCore);
            await _repository.UpdateAsync(tData);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok( CustomResult<T>.Success($"{typeof(T).Name} is updated") );
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TId id, CancellationToken cancellationToken)
        {
            var tEntity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(tEntity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok( CustomResult.Success($"{nameof(T)} deleted") );
        }

    }
}
