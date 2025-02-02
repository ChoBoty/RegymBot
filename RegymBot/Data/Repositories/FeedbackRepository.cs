﻿using Microsoft.Extensions.Logging;
using RegymBot.Data.Base;
using RegymBot.Data.Entities;
using System;
using System.Threading.Tasks;

namespace RegymBot.Data.Repositories
{
    public class FeedbackRepository : BaseRepository<FeedbackEntity>
    {
        public FeedbackRepository(AppDbContext context, ILogger logger)
            : base(context, logger) { }

        public async Task AddNewFeedback(string text, long userId)
        {
            try
            {
                var feedback = new FeedbackEntity
                {
                    Feedback = text,
                    UserId = userId
                };

                await Insert(feedback);
                _logger.LogInformation($"Write new record in feedback table from userId: {userId}");
            }
            catch(Exception e)
            {
                _logger.LogError(e, $"Error on get all {typeof(FeedbackEntity)}");
                throw;
            }
        }
    }
}
