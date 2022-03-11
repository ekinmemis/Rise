using MongoDB.Driver;

using Rise.Phone.Core.Domain.Phone;

using System;
using System.Collections.Generic;

namespace Rise.Phone.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="PhoneDbSeeder" />.
    /// </summary>
    public partial class MongoDbInitializer : IDbInitializer
    {
        /// <summary>
        /// Defines the _mongoDbSettings.
        /// </summary>
        private readonly PhoneDbSettings _mongoDbSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbInitializer"/> class.
        /// </summary>
        /// <param name="mongoDbSettings">The mongoDbSettings<see cref="PhoneDbSettings"/>.</param>
        public MongoDbInitializer(PhoneDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
        }

        /// <summary>
        /// The SeedData.
        /// </summary>
        public void Initialize()
        {
            try
            {
                var client = new MongoClient(_mongoDbSettings.ConnectionString);

                var database = client.GetDatabase(_mongoDbSettings.Database);

                database.CreateMongoCollection(nameof(Person));
                database.CreateMongoCollection(nameof(Contact));


                var PersonsCollection = database.GetCollection<Person>(nameof(Person));
                bool existPersons = PersonsCollection.Find(p => true).Any();
                if (!existPersons)
                    PersonsCollection.InsertManyAsync(SeedPersons());

                var ContactCollection = database.GetCollection<Contact>(nameof(Contact));
                bool existContacts = ContactCollection.Find(p => true).Any();
                if (!existContacts)
                    ContactCollection.InsertManyAsync(SeedContacts());
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// The SeedPersons.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Person}"/>.</returns>
        private static IEnumerable<Person> SeedPersons()
        {
            return new List<Person>() {

                new Person
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

                },

                new Person
                {
                     Id="60045edfd72749acbdd27b45",
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
                },

                new Person
                {
                     Id = "60045ed14733501b66f2607d",
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
                }
            };
        }

        /// <summary>
        /// The SeedContacts.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Contact}"/>.</returns>
        private static IEnumerable<Contact> SeedContacts()
        {
            return new List<Contact> {
                new Contact {
                     Id="60045ecceb9142723a47eadb",
                     Name = "Ekin",
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
        }
    }
}
