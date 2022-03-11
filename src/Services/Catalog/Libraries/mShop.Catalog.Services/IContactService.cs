using Rise.Core;
using Rise.Phone.Core.Domain.Phone;

using System.Collections.Generic;

namespace Rise.Phone.Services
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IContactService" />.
    /// </summary>
    public partial interface IContactService : IServiceBase<Contact>
    {
        #region Methods

        /// <summary>
        /// The SearchPersons.
        /// </summary>
        /// <returns>The <see cref="List{Contact}"/>.</returns>
        List<Contact> GetAll();

        /// <summary>
        /// The SearchPersons.
        /// </summary>
        /// <param name="name">The PersonName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Person}"/>.</returns>
        IPagedList<Contact> SearchContacts(string name = "", int pageIndex = 0,
            int pageSize = int.MaxValue, bool loadOnlyTotalCount = false);

        #endregion
    }

    #endregion
}
