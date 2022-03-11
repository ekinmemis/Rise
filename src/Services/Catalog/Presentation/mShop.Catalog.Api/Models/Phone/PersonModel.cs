using Rise.Phone.Core.Domain.Phone;
using System.Collections.Generic;

namespace Rise.Phone.Api.Models.Phone
{
    /// <summary>
    /// Defines the <see cref="PersonModel" />.
    /// </summary>
    public partial class PersonModel : BaseFullAuditedEntityModel
    {
        /// <summary>
        /// Gets or sets the Company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Surname.
        /// </summary>
        public string Surname { get; set; }
    }
}
