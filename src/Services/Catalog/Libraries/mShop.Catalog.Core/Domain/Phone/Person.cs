using System.Collections.Generic;

namespace Rise.Phone.Core.Domain.Phone
{
    /// <summary>
    /// Defines the <see cref="Person" />.
    /// </summary>
    public partial class Person : FullAuditedEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the Contacts.
        /// </summary>
        public IList<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Surname.
        /// </summary>
        public string Surname { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The Clone.
        /// </summary>
        /// <returns>The <see cref="object"/>.</returns>
        public object Clone()
        {
            return new Person()
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Company = Company
            };
        }

        #endregion
    }
}
