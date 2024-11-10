using ArtifactsMMO.NET.Enums.ErrorCodes.Action;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.MyCharacter;
using ArtifactsMMO.NET.Objects.MyCharacter.Bank;
using ArtifactsMMO.NET.Objects.MyCharacter.Fight;
using ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.MyCharacters
{
    internal class MyCharacters : ArtifactsMMOEndpoint, IMyCharacters
    {
        private readonly IValidator<string> _nameValidator = new CharacterNameValidator();
        public MyCharacters(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal MyCharacters(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<(CharacterMovementData result, MoveError? error)> MoveAsync(string name, MoveRequest moveRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<CharacterMovementData, MoveError>($"my/{name}/action/move", moveRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(EquipItem result, EquipItemError? error)> EquipItemAsync(string name, EquipItemRequest equipItemRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<EquipItem, EquipItemError>($"my/{name}/action/equip", equipItemRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(EquipItem result, UnequipItemError? error)> UnequipItemAsync(string name, UnequipItemReguest unequipItemReguest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<EquipItem, UnequipItemError>($"my/{name}/action/unequip", unequipItemReguest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(CharacterFightData result, FightError? error)> FightAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<CharacterFightData, FightError>($"my/{name}/action/fight", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(SkillData result, GatheringError? error)> GatheringAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<SkillData, GatheringError>($"my/{name}/action/gathering", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(SkillData result, CraftingError? error)> CraftingAsync(string name, CraftingRequest craftingRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<SkillData, CraftingError>($"my/{name}/action/crafting", craftingRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(BankItemTransaction result, DepositBankError? error)> DepositBankAsync(string name, DepositBankRequest depositBankRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<BankItemTransaction, DepositBankError>($"my/{name}/action/bank/deposit", depositBankRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(BankGoldTransaction result, DepositBankGoldError? error)> DepositBankGoldAsync(string name, DepositBankGoldRequest depositBankGoldRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<BankGoldTransaction, DepositBankGoldError>($"my/{name}/action/bank/deposit/gold", depositBankGoldRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(RecyclingData result, RecyclingError? error)> RecyclingAsync(string name, RecyclingRequest recyclingRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<RecyclingData, RecyclingError>($"my/{name}/action/recycling", recyclingRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(BankItemTransaction result, WithdrawBankError? error)> WithdrawBankAsync(string name, WithdrawBankRequest withdrawBankRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<BankItemTransaction, WithdrawBankError>($"my/{name}/action/bank/withdraw", withdrawBankRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(BankGoldTransaction result, WithdrawBankGoldError? error)> WithdrawBankGoldAsync(string name, WithdrawBankGoldRequest withdrawBankGoldRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<BankGoldTransaction, WithdrawBankGoldError>($"my/{name}/action/bank/withdraw/gold", withdrawBankGoldRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(GrandExchangeTransactionData result, GrandExchangeBuyItemError? error)> GrandExchangeBuyItemAsync(string name, GrandExchangeBuyItemRequest grandExchangeBuyItemRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<GrandExchangeTransactionData, GrandExchangeBuyItemError>($"my/{name}/action/grandexchange/buy", grandExchangeBuyItemRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(GrandExchangeOrderTransaction result, GrandExchangeCreateSellOrderError? error)> GrandExchangeCreateSellOrderAsync(string name, GrandExchangeCreateSellOrderRequest grandExchangeCreateSellOrderRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<GrandExchangeOrderTransaction, GrandExchangeCreateSellOrderError>($"my/{name}/action/grandexchange/sell", grandExchangeCreateSellOrderRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(GrandExchangeTransactionData result, GrandExchangeCancelSellOrderError? error)> GrandExchangeCancelSellOrderAsync(string name, GrandExchangeCancelSellOrderRequest grandExchangeCancelSellOrderRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<GrandExchangeTransactionData, GrandExchangeCancelSellOrderError>($"my/{name}/action/grandexchange/cancel", grandExchangeCancelSellOrderRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(BankExtensionTransaction result, BuyBankExpansionError? error)> BuyBankExpansionAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<BankExtensionTransaction, BuyBankExpansionError>($"my/{name}/action/bank/buy_expansion", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(TaskData result, AcceptNewTaskError? error)> AcceptNewTaskAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<TaskData, AcceptNewTaskError>($"my/{name}/action/task/new", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(TaskRewardData result, CompleteTaskError? error)> CompleteTaskAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<TaskRewardData, CompleteTaskError>($"my/{name}/action/task/complete", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(TaskRewardData result, TaskExchangeError? error)> TaskExchangeAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<TaskRewardData, TaskExchangeError>($"my/{name}/action/task/exchange", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(TaskTradeData result, TaskTradeError? error)> TaskTradeAsync(string name, TaskTradeRequest taskTradeRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<TaskTradeData, TaskTradeError>($"my/{name}/action/task/trade", taskTradeRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(TaskCancelled result, TaskCancelledError? error)> TaskCancelAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<TaskCancelled, TaskCancelledError>($"my/{name}/action/task/cancel", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(DeleteItem result, DeleteItemError? error)> DeleteItemAsync(string name, DeleteItemRequest deleteItemRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<DeleteItem, DeleteItemError>($"my/{name}/action/delete", deleteItemRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(UseItem result, UseItemError? error)> UseItemAsync(string name, UseItemRequest useItemRequest, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<UseItem, UseItemError>($"my/{name}/action/use", useItemRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(CharacterRestData result, RestError? error)> RestAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await PostAsync<CharacterRestData, RestError>($"my/{name}/action/rest", null, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(PagedResponse<Log> result, GetAllCharactersLogsError? error)> GetAllCharactersLogsAsync(AllCharactersLogsQuery allCharactersLogsQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Log, GetAllCharactersLogsError>($"my/logs", allCharactersLogsQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Character>> GetMyCharactersAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<Character>>($"my/characters", cancellationToken).ConfigureAwait(false);
        }
    }
}
