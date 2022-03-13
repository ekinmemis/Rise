using NUnit.Framework;

using Rise.Phone.Core.Domain.Phone;
using Rise.Tests;

using System;

namespace Rise.Core.Test.Domain.Phone
{
    /// <summary>
    /// Defines the <see cref="ContactTest" />.
    /// </summary>
    [TestFixture]
    public class ContactTest
    {
        #region Methods

        /// <summary>
        /// The Can_clone_contact.
        /// </summary>
        [Test]
        public void Can_clone_contact()
        {
            Contact Contact = new Contact
            {
                Id = "60045ee5f41e850d9359d93",
                CreatedById = 1,
                UpdatedById = 1,
                DeletedById = 0,
                Email = "memis.ekin@gmail.com",
                Info = "Test",
                Location = "Test",
                PersonId = "60045ecceb9142723a47eadb",
                Phone = "533 436 61 26",
                Active = true,
                Deleted = false,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            };

            Contact newContact = Contact.Clone() as Contact;

            newContact.ShouldNotBeNull();
            newContact.Id.ShouldEqual("60045ee5f41e850d9359d93");
            newContact.Deleted.ShouldEqual(false);
        }

        #endregion
    }
}
