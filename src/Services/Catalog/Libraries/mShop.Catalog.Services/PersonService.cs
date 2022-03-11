using Rise.Core;
using Rise.Phone.Core.Domain.Phone;

using System.Collections.Generic;
using System.Linq;

namespace Rise.Phone.Services
{
    /// <summary>
    /// Defines the <see cref="PersonService" />.
    /// </summary>
    public partial class PersonService : ServiceBase<Person>, IPersonService
    {
        #region Methods

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{Person}"/>.</returns>
        public List<Person> GetAll()
        {
            return _repository.Table.ToList();
        }

        /// <summary>
        /// The SearchPersons.
        /// </summary>
        /// <param name="PersonName">The PersonName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Person}"/>.</returns>
        public IPagedList<Person> SearchPersons(string PersonName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool loadOnlyTotalCount = false)
        {
            IQueryable<Person> query = base._repository.Table;

            if (!string.IsNullOrEmpty(PersonName))
            {
                query = query.Where(p => p.Name == PersonName);
            }

            query = query.OrderBy(p => p.Id);

            PagedList<Person> data = new PagedList<Person>(query, pageIndex, pageSize, loadOnlyTotalCount);

            return data;
        }

        #endregion
    }
}
