using Rise.Core;
using Rise.Phone.Core.Domain.Phone;

using System.Collections.Generic;
using System.Linq;

namespace Rise.Phone.Services
{
    /// <summary>
    /// Defines the <see cref="ContactService" />.
    /// </summary>
    public partial class ContactService : ServiceBase<Contact>, IContactService
    {
        #region Methods

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{Contact}"/>.</returns>
        public List<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// The SearchContacts.
        /// </summary>
        /// <param name="name">The ContactName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Contact}"/>.</returns>
        public IPagedList<Contact> SearchContacts(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool loadOnlyTotalCount = false)
        {
            IQueryable<Contact> query = _repository.Table;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            query = query.OrderBy(p => p.Id);

            PagedList<Contact> data = new PagedList<Contact>(query, pageIndex, pageSize, loadOnlyTotalCount);

            return data;
        }

        #endregion
    }
}
