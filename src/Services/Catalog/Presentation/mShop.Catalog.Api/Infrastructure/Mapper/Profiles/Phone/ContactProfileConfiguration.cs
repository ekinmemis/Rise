using AutoMapper;

using Rise.Core.Infrastructure.Mapper;
using Rise.Phone.Api.Models.Phone;
using Rise.Phone.Core.Domain.Phone;

namespace Rise.Phone.Api.Infrastructure.Mapper.Profiles.Phone
{
    public partial class ContactProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonProfileConfiguration"/> class.
        /// </summary>
        public ContactProfileConfiguration()
        {
            InitPersonProfiles();
        }

        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => 1;

        /// <summary>
        /// The InitPersonProfiles.
        /// </summary>
        protected virtual void InitPersonProfiles()
        {
            CreateMap<ContactModel, Contact>()
                .ForMember(p => p.CreatedById, opt => opt.Ignore());

            CreateMap<Contact, ContactModel>();
        }
    }
}
