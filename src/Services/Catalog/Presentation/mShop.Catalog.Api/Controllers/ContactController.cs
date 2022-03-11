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
    public partial class ContactController : ControllerBase
    {
        [HttpGet("Search")]
        public virtual IActionResult Get([FromQuery] ContactSearchModel model)
        {
            var _contactService = EngineContext.Current.Resolve<IContactService>();

            var contacts = _contactService.SearchContacts(model.Name, pageIndex: model.PageIndex,
                pageSize: model.PageSize, model.LoadOnlyTotalCount);

            var data = new ContactListModel
            {
                Data = contacts.Select(x =>
                {
                    return x.ToModel<ContactModel>();
                }),
                TotalCount = contacts.TotalCount,
            };

            return Ok(data);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var _contactService = EngineContext.Current.Resolve<IContactService>();

            var contact = await _contactService.GetByIdAsync(id);

            var model = contact.ToModel<ContactModel>();

            var result = new SuccessDataResult(model);
            return Ok(result);
        }

        [HttpPost("Create")]
        public virtual async Task<IActionResult> Post([FromBody] ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorResult = new ErrorResult(ErrorMessage.ModelStateInvalid);
                return BadRequest(errorResult);
            }

            var contact = model.ToEntity<Contact>();

            var _contactService = EngineContext.Current.Resolve<IContactService>();

            await _contactService.InsertAsync(contact);

            var result = new SuccessResult(SuccessMessage.ContactInserted);

            return Ok(result);
        }

        [HttpPut("Update")]
        public virtual async Task<IActionResult> Put([FromBody] ContactModel model)
        {
            var _contactService = EngineContext.Current.Resolve<IContactService>();

            var contact = await _contactService.GetByIdAsync(model.Id);

            contact = model.ToEntity(contact);

            await _contactService.UpdateAsync(contact);

            var result = new SuccessResult(SuccessMessage.ContactUpdated);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            var _contactService = EngineContext.Current.Resolve<IContactService>();

            await _contactService.DeleteByIdAsync(id);

            var result = new SuccessResult(SuccessMessage.ContactDeleted);

            return Ok(result);
        }
    }
}
