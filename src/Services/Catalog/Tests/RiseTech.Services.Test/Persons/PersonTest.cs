using Moq;

using NUnit.Framework;

using Rise.Phone.Core.Domain.Phone;
using Rise.Phone.Data;
using Rise.Phone.Services;
using Rise.Tests;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Rise.Services.Test.Persons
{
    /// <summary>
    /// Defines the <see cref="PersonTest" />.
    /// </summary>
    [TestFixture]
    public class PersonTest
    {
        #region Fields

        /// <summary>
        /// Defines the _personRepository.
        /// </summary>
        private IRepository<Person> _personRepository;

        /// <summary>
        /// Defines the _persons.
        /// </summary>
        private List<Person> _persons;

        /// <summary>
        /// Defines the _personService.
        /// </summary>
        private IPersonService _personService;

        #endregion

        #region Methods

        /// <summary>
        /// The can_add_person.
        /// </summary>
        [Test]
        public void can_add_person()
        {
            Person appUser = new Person()
            {
                Id = "60045ecceb9142723a47eadb",
                Name = "Ekin",
                Surname = "Memis",
                Company = "Rise Technology",
                CreatedById = 1,
                UpdatedById = 1,
                DeletedById = 0,
                Active = true,
                Deleted = false,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow
            };

            _personRepository.Insert(appUser);

            Person addedUser = _personRepository.GetById("60045ecceb9142723a47eadb");

            addedUser.ShouldNotBeNull();
        }

        /// <summary>
        /// The can_delete_person.
        /// </summary>
        [Test]
        public void can_delete_person()
        {
            _personRepository.Delete(_personRepository.GetById("60045ecceb9142723a47eadb"));

            Person deletedUser = _personRepository.GetById("60045ecceb9142723a47eadb");

            deletedUser.ShouldBeNull();
        }


        /// <summary>
        /// The can_update_person.
        /// </summary>
        [Test]
        public void can_update_person()
        {
            Person person = _personRepository.GetById("60045ecceb9142723a47eadb");

            person.Name = "First Name -UPDATED";

            _personRepository.Update(person);

            Person updatedUser = _personRepository.GetById("60045ecceb9142723a47eadb");

            updatedUser.ShouldNotBeNull();
        }

        /// <summary>
        /// The Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _persons = SetUpPersons();
            _personRepository = SetUpPersonRepository();
            _personService = new PersonService();
        }

        /// <summary>
        /// The SetUpPersons.
        /// </summary>
        /// <returns>The <see cref="List{Person}"/>.</returns>
        private static List<Person> SetUpPersons()
        {
            List<Person> persons = new List<Person>
            {
                new Person
                {
                     Id = "60045ecceb9142723a47eadb",
                     Name = "Ekin",
                     Surname = "Memis",
                     Company = "Rise Technology",
                     CreatedById=1,
                     UpdatedById=1,
                     DeletedById=0,
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow
                },
                new Person()
                {
                     Id = "60045ecceb9142723a47eadc",
                     Name = "Ekin",
                     Surname = "Memis",
                     Company = "Rise Technology",
                     CreatedById=1,
                     UpdatedById=1,
                     DeletedById=0,
                     Active = true,
                     Deleted = false,
                     CreatedOnUtc = DateTime.UtcNow,
                     UpdatedOnUtc = DateTime.UtcNow
                },
            };

            return persons;
        }

        /// <summary>
        /// The SetUpPersonRepository.
        /// </summary>
        /// <returns>The <see cref="IRepository{Person}"/>.</returns>
        private IRepository<Person> SetUpPersonRepository()
        {
            Mock<IRepository<Person>> mockRepo = new Mock<IRepository<Person>>();

            mockRepo.Setup(p => p.GetAll()).Returns(_persons);

            mockRepo.Setup(p => p.GetById(It.IsAny<string>())).Returns(new Func<string, Person>(id => _persons.Find(p => p.Id.Equals(id))));

            mockRepo.Setup(p => p.Insert(It.IsAny<Person>())).Callback(new Action<Person>(newPerson =>
            {
                dynamic maxPersonID = _persons.Last().Id; dynamic nextPersonID = maxPersonID + 1; newPerson.Id = nextPersonID; _persons.Add(newPerson);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Person>())).Callback(new Action<Person>(person =>
            {
                Person oldPerson = _persons.Find(a => a.Id == person.Id); oldPerson = person;
            }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Person>())).Callback(new Action<Person>(person =>
            {
                Person personToRemove = _persons.Find(a => a.Id == person.Id); if (personToRemove != null)
                {
                    _persons.Remove(personToRemove);
                }
            }));

            return mockRepo.Object;
        }

        #endregion
    }
}
