using CryptoPortfolio.Business.Entities.Coindar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Interfaces.Coindar
{
    public interface ICoindarRepository
    {
        /// <summary>
        /// Get upcoming calendar items for a coin
        /// </summary>
        /// <param name="coinName">String of coin name</param>
        /// <returns>Collection of CalendarItem</returns>
        Task<IEnumerable<CalendarItem>> GetCalendarItem(string coinName);
    }
}
