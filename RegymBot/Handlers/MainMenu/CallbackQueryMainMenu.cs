﻿using Microsoft.Extensions.Logging;
using RegymBot.Data.Entities;
using RegymBot.Data.Enums;
using RegymBot.Data.Repositories;
using RegymBot.Helpers.Buttons;
using RegymBot.Helpers.StateContext;
using RegymBot.Services;
using System.Threading.Tasks;
using Telegram.Bot;

namespace RegymBot.Handlers.MainMenu
{
    public class CallbackQueryMainMenu : BaseCallback<CallbackQueryMainMenu>
    {
        private readonly PriceRepository _priceRepository;
        private readonly StaticMessageRepository _staticMessageRepository;

        public CallbackQueryMainMenu(ITelegramBotClient botClient,
             PriceRepository priceRepository,
             StaticMessageRepository staticMessageRepository,
             ILogger<CallbackQueryMainMenu> logger,
             IStepService stepService) : base(stepService, botClient, logger)
        {
            _priceRepository = priceRepository;
            _staticMessageRepository = staticMessageRepository;
        }

        public async Task BotOnCallbackQueryReceived(Telegram.Bot.Types.CallbackQuery callbackQuery)
        {
            _logger.LogInformation("Received callback query in main menu from: {CallQueryFromId}", callbackQuery.From.Id);
            string text;

            switch (callbackQuery.Data)
            {
                case "select_club":
                    text = await _staticMessageRepository.GetMessageByTypeAsync(BotPage.SelectClubPage);
                    _stepService.NewStep(BotStep.ClubList, callbackQuery.From.Id);

                    await _botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                    text: text,
                                                    replyMarkup: ClubButtons.Keyboard);

                    break;
                case "price":
                    var prices = await _priceRepository.GetAllAsync();
                    text = await _staticMessageRepository.GetMessageByTypeAsync(BotPage.PricePage);
                    _stepService.NewStep(BotStep.Price, callbackQuery.From.Id);

                    foreach (PriceEntity price in prices)
                    {
                        text += $"\n- {price.PriceName} - {price.Price};";
                    }

                    await _botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                    text: text,
                                                    replyMarkup: ReturnBackButton.Keyboard);

                    break;

                case "solarium":
                    text = await _staticMessageRepository.GetMessageByTypeAsync(BotPage.SolariumPage);
                    var pricesSolarium = await _priceRepository.GetPricesByTypeAsync(PriceItem.Solarium);
                    _stepService.NewStep(BotStep.Solarium, callbackQuery.From.Id);

                    foreach (PriceEntity price in pricesSolarium)
                    {
                        text += $"\n- {price.PriceName} - {price.Price};";
                    }

                    await _botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                    text: text,
                                                    replyMarkup: ReturnBackButton.Keyboard);

                    break;

                case "massage":
                    text = await _staticMessageRepository.GetMessageByTypeAsync(BotPage.MassagePage);
                    var pricesMassage = await _priceRepository.GetPricesByTypeAsync(PriceItem.Massage);
                    _stepService.NewStep(BotStep.Massage, callbackQuery.From.Id);

                    foreach (PriceEntity price in pricesMassage)
                    {
                        text += $"\n- {price.PriceName} - {price.Price};";
                    }

                    await _botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                    text: text,
                                                    replyMarkup: ReturnBackButton.Keyboard);

                    break;

                case "feedback":
                    text = await _staticMessageRepository.GetMessageByTypeAsync(BotPage.LeaveFeedbackPage);
                    _stepService.NewStep(BotStep.LeaveFeedback, callbackQuery.From.Id);

                    await _botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                                                    text: text,
                                                    replyMarkup: ReturnBackButton.Keyboard);

                    break;
            }
        }
    }
}
