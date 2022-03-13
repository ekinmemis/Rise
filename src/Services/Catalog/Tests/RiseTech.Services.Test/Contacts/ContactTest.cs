using Moq;

using NUnit.Framework;

using Rise.Phone.Core.Domain.Phone;
using Rise.Phone.Data;
using Rise.Phone.Services;
using Rise.Tests;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rise.Services.Test.Contacts
{
    public class ContactTest
    {
        private List<Contact> _contacts;
        private IRepository<Contact> _contactRepository;
        private IContactService _contactService;

        private IRepository<Contact> SetUpContactRepository()
        {
            Mock<IRepository<Contact>> mockRepo = new Mock<IRepository<Contact>>();

            mockRepo.Setup(p => p.GetAll()).Returns(_contacts);

            mockRepo.Setup(p => p.GetById(It.IsAny<string>())).Returns(new Func<string, Contact>(id => _contacts.Find(p => p.Id.Equals(id))));

            mockRepo.Setup(p => p.Insert(It.IsAny<Contact>())).Callback(new Action<Contact>(newContact =>
            {
                dynamic maxContactID = _contacts.Last().Id; dynamic nextContactID = maxContactID + 1; newContact.Id = nextContactID; _contacts.Add(newContact);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Contact>())).Callback(new Action<Contact>(contact =>
            {
                Contact oldContact = _contacts.Find(a => a.Id == contact.Id); oldContact = contact;
            }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Contact>())).Callback(new Action<Contact>(contact =>
            {
                Contact contactToRemove = _contacts.Find(a => a.Id == contact.Id); if (contactToRemove != null)
                {
                    _contacts.Remove(contactToRemove);
                }
            }));

            return mockRepo.Object;
        }

        private static List<Contact> SetUpContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                     Id="60045edfd72749acbdd27b45",
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
                },

                new Contact
                {
                     Id = "60045ed14733501b66f2607d",
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
                }
            };

            return contacts;
        }

        [SetUp]
        public void Setup()
        {
            _contacts = SetUpContacts();
            _contactRepository = SetUpContactRepository();
            _contactService = new ContactService();
        }

        [Test]
        public void can_add_contact()
        {
            Contact contact = new Contact()
            {
                Id = "60045edfd72749acbdd27b45",
                Deleted = false,
            };

            _contactRepository.Insert(contact);

            Contact addedContact = _contactRepository.GetById("60045edfd72749acbdd27b45");

            addedContact.ShouldNotBeNull();
        }

        [Test]
        public void can_update_contact()
        {
            Contact contact = _contactRepository.GetById("60045edfd72749acbdd27b45");

            contact.Info = "Info -UPDATED";

            _contactRepository.Update(contact);

            Contact updatedContact = _contactRepository.GetById("60045edfd72749acbdd27b45");

            updatedContact.ShouldNotBeNull();
        }

        [Test]
        public void can_delete_contact()
        {
            _contactRepository.Delete(_contactRepository.GetById("60045edfd72749acbdd27b45"));

            Contact deletedContact = _contactRepository.GetById("60045edfd72749acbdd27b45");

            deletedContact.ShouldBeNull();
        }
    }
}
