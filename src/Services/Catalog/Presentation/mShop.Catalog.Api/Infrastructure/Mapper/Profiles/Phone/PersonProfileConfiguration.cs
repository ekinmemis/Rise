using AutoMapper;
using Rise.Phone.Api.Models.Phone;
using Rise.Phone.Core.Domain.Phone;
using Rise.Core.Infrastructure.Mapper;

namespace Rise.Phone.Api.Infrastructure.Mapper.Profiles.Phone
{
    /// <summary>
    /// Defines the <see cref="PersonProfileConfiguration" />.
    /// </summary>
    public partial class PersonProfileConfiguration : Profile, IOrderedMapperProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonProfileConfiguration"/> class.
        /// </summary>
        public PersonProfileConfiguration()
        {
            this.InitPersonProfiles();
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
            CreateMap<PersonModel, Person>()
                .ForMember(p => p.CreatedById, opt => opt.Ignore());

            CreateMap<Person, PersonModel>();

            
        }
    }
}
