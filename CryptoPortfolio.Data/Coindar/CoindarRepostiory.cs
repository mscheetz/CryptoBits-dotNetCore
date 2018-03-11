using CryptoPortfolio.Business.Entities.Coindar;
using CryptoPortfolio.Data.Interfaces;
using CryptoPortfolio.Data.Interfaces.Coindar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data.Coindar
{
    public class CoindarRepostiory : ICoindarRepository
    {
        private IRESTRepository _restRepo;
        private string baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        public CoindarRepostiory()
        {
            _restRepo = new RESTRepository();
            baseUrl = "https://coindar.org";
        }

        /// <summary>
        /// Get upcoming calendar items for a coin
        /// </summary>
        /// <param name="coinName">String of coin name</param>
        /// <returns>Collection of CalendarItem</returns>
        public async Task<IEnumerable<CalendarItem>> GetCalendarItem(string coinName)
        {
            var url = this.baseUrl + $"/api/v1/coinEvents?name={coinName}";

            var response = await this._restRepo.GetApi<List<CalendarItem>>(url);

            return response;
        }
    }
}
