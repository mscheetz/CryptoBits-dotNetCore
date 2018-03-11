using CryptoPortfolio.Business.Builder.Interfaces.Sources;
using CryptoPortfolio.Business.Contracts.Sources;
using System;
using System.Collections.Generic;
using System.Text;
using CryptoPortfolio.Business.Helper;
using CryptoPortfolio.Data.Interfaces.Coindar;
using CryptoPortfolio.Data.Coindar;

namespace CryptoPortfolio.Business.Builder.Sources
{
    public class CoindarBuilder : ICoindarBuilder
    {
        private ICoindarRepository _repo;
        private ObjectHelper _helper;

        public CoindarBuilder()
        {
            _repo = new CoindarRepostiory();
            this._helper = new ObjectHelper();
        }

        /// <summary>
        /// Get Events for a given coin
        /// </summary>
        /// <param name="coinName">String of coin name</param>
        /// <returns>Collection of Cal</returns>
        public IEnumerable<Event> GetEvents(string coinName)
        {
            var calendarEntityList = _repo.GetCalendarItem(coinName).Result;

            return GetContractList(calendarEntityList);
        }

        private List<Event> GetContractList(IEnumerable<Entities.Coindar.CalendarItem> entityList)
        {
            return this._helper.CreateContract<IEnumerable<Entities.Coindar.CalendarItem>, List<Event>>(entityList);
        }
    }
}
