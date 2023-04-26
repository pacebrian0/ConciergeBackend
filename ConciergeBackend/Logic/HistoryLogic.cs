﻿using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class HistoryLogic : IHistoryLogic
    {
        private readonly IHistoryData _data;

        public HistoryLogic(IHistoryData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<History>> GetHistorys()
        {
            
            return await _data.GetHistories();

        }
        public async Task<History> GetHistoryById(string id)
        {
            return await _data.GetHistoryById(id);

        }

        public async Task PostHistory(History history)
        {

            //do local logic
            await _data.PostHistory(history, true);

            //do remote logic
            try
            {
                await _data.PostHistory(history, false);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteHistory(History audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteHistory(audit, true);
        }
    }
}
