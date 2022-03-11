using MongoDB.Bson.Serialization.Attributes;

namespace Rise.Phone.Core.Domain.Phone
{
    /// <summary>
    /// Defines the <see cref="Contact" />.
    /// </summary>
    public partial class Contact : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Info { get; set; }
        public string PersonId { get; set; }

        public object Clone()
        {
            return new Contact()
            {
                Name = Name,
                Phone = Phone,
                Email = Email,
                Location = Location,
                Info = Info,
                PersonId = PersonId
            };
        }
    }
}
