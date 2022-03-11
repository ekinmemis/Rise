using Rise.Core;
using Rise.Phone.Core.Domain.Phone;

using System.Collections.Generic;

namespace Rise.Phone.Services
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IPersonService" />.
    /// </summary>
    public partial interface IPersonService : IServiceBase<Person>
    {
        #region Methods

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="List{Person}"/>.</returns>
        List<Person> GetAll();

        /// <summary>
        /// The SearchPersons.
        /// </summary>
        /// <param name="PersonName">The PersonName<see cref="string"/>.</param>
        /// <param name="pageIndex">The pageIndex<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="loadOnlyTotalCount">The loadOnlyTotalCount<see cref="bool"/>.</param>
        /// <returns>The <see cref="IPagedList{Person}"/>.</returns>
        IPagedList<Person> SearchPersons(string PersonName = "", int pageIndex = 0,
            int pageSize = int.MaxValue, bool loadOnlyTotalCount = false);

        #endregion
    }

    #endregion
}
