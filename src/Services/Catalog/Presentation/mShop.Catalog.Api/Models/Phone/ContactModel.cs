namespace Rise.Phone.Api.Models.Phone
{
    /// <summary>
    /// Defines the <see cref="ContactModel" />.
    /// </summary>
    public partial class ContactModel : BaseEntityModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Info.
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the PersonId.
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// Gets or sets the Phone.
        /// </summary>
        public string Phone { get; set; }

        #endregion
    }
}
