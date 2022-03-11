using Microsoft.AspNetCore.Mvc;
using Rise.Phone.Api.Infrastructure.Mapper.Extensions;
using Rise.Phone.Api.Models.Phone;
using Rise.Phone.Api.Models.Messages;
using Rise.Phone.Core.Domain.Phone;
using Rise.Phone.Services;
using Rise.Core.Infrastructure;
using Rise.Core.Results;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.Phone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class PersonController : ControllerBase
    {
        [HttpGet("Search")]
        public virtual IActionResult Get([FromQuery] PersonSearchModel model)
        {
            var _personService = EngineContext.Current.Resolve<IPersonService>();

            var Persons = _personService.SearchPersons(model.PersonName, pageIndex: model.PageIndex,
                pageSize: model.PageSize, model.LoadOnlyTotalCount);

            var data = new PersonListModel
            {
                Data = Persons.Select(x =>
                {
                    return x.ToModel<PersonModel>();
                }),
                TotalCount = Persons.TotalCount, 
            };

            return Ok(data);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var _personService = EngineContext.Current.Resolve<IPersonService>();

            var Person = await _personService.GetByIdAsync(id);

            var model = Person.ToModel<PersonModel>();

            var result = new SuccessDataResult(model);
            return Ok(result);
        }

        [HttpPost("Create")]
        public virtual async Task<IActionResult> Post([FromBody] PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorResult = new ErrorResult(ErrorMessage.ModelStateInvalid);
                return BadRequest(errorResult);
            }

            var Person = model.ToEntity<Person>();

            var _personService = EngineContext.Current.Resolve<IPersonService>();

            await _personService.InsertAsync(Person);

            var result = new SuccessResult(SuccessMessage.PersonInserted);

            return Ok(result);
        }

        [HttpPut("Update")]
        public virtual async Task<IActionResult> Put([FromBody] PersonModel model)
        {
            var _personService = EngineContext.Current.Resolve<IPersonService>();

            var Person = await _personService.GetByIdAsync(model.Id);

            Person = model.ToEntity(Person);

            await _personService.UpdateAsync(Person);

            var result = new SuccessResult(SuccessMessage.PersonUpdated);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            var _personService = EngineContext.Current.Resolve<IPersonService>();

            await _personService.DeleteByIdAsync(id);

            var result = new SuccessResult(SuccessMessage.PersonDeleted);

            return Ok(result);
        }
    }
}
