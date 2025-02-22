using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.MyCharacter.Bank;
using ArtifactsMMO.NET.Objects.MyCharacter.Fight;
using ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange;
using ArtifactsMMO.NET.Objects.MyCharacter;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Enums.ErrorCodes.Action;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Objects.MyCharacter.Npc;

namespace ArtifactsMMO.NET.Endpoints.MyCharacters
{
    /// <summary>
    /// Provides methods for character actions in the game.
    /// </summary>
    public interface IMyCharacters
    {
        /// <summary>
        /// Moves a character on the map using the map's X and Y position.
        /// </summary>
        /// <param name="name">The name of the character to move.</param>
        /// <param name="moveRequest">The request <see cref="MoveRequest"/> containing movement details.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="CharacterMovementData"/>
        /// and an optional <see cref="MoveError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(CharacterMovementData result, MoveError? error)> MoveAsync(string name, MoveRequest moveRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Equip an item on your character.
        /// </summary>
        /// <param name="name">The name of the character to whom the item will be equipped.</param>
        /// <param name="equipItemRequest">The request <see cref="EquipItemRequest"/> containing details about the item to be equipped.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="EquipItem"/>
        /// and an optional <see cref="EquipItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(EquipItem result, EquipItemError? error)> EquipItemAsync(string name, EquipItemRequest equipItemRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Unequip an item on your character.
        /// </summary>
        /// <param name="name">The name of the character from whom the item will be unequipped.</param>
        /// <param name="unequipItemReguest">The request <see cref="UnequipItemReguest"/> containing details about the item to be unequipped.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="EquipItem"/>
        /// and an optional <see cref="UnequipItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(EquipItem result, UnequipItemError? error)> UnequipItemAsync(string name, UnequipItemReguest unequipItemReguest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a fight against a monster on the character's map.
        /// </summary>
        /// <param name="name">The name of the character initiating the fight.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="CharacterFightData"/>
        /// and an optional <see cref="FightError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(CharacterFightData result, FightError? error)> FightAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Harvest a resource on the character's map.
        /// </summary>
        /// <param name="name">The name of the character gathering resources.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="SkillData"/>
        /// and an optional <see cref="GatheringError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(SkillData result, GatheringError? error)> GatheringAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Crafting an item. The character must be on a map with a workshop.
        /// </summary>
        /// <param name="name">The name of the character crafting items.</param>
        /// <param name="craftingRequest">The request <see cref="CraftingRequest"/> containing details about the items to be crafted.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="SkillData"/>
        /// and an optional <see cref="CraftingError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(SkillData result, CraftingError? error)> CraftingAsync(string name, CraftingRequest craftingRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deposit an item in a bank on the character's map.
        /// </summary>
        /// <param name="name">The name of the character making the deposit.</param>
        /// <param name="depositBankRequest">The request <see cref="DepositBankRequest"/> containing details about the item to be deposited.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="BankItemTransaction"/>
        /// and an optional <see cref="DepositBankError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(BankItemTransaction result, DepositBankError? error)> DepositBankAsync(string name, DepositBankRequest depositBankRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deposit gold in a bank on the character's map.
        /// </summary>
        /// <param name="name">The name of the character making the deposit.</param>
        /// <param name="depositBankGoldRequest">The request <see cref="DepositBankGoldRequest"/> containing the amount of gold to be deposited.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="BankGoldTransaction"/>
        /// and an optional <see cref="DepositBankGoldError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(BankGoldTransaction result, DepositBankGoldError? error)> DepositBankGoldAsync(string name, DepositBankGoldRequest depositBankGoldRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recyling an item. The character must be on a map with a workshop (only for equipments and weapons).
        /// </summary>
        /// <param name="name">The name of the character performing the recycling.</param>
        /// <param name="recyclingRequest">The request <see cref="RecyclingRequest"/> containing details about the items to be recycled.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="RecyclingData"/>
        /// and an optional <see cref="RecyclingError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(RecyclingData result, RecyclingError? error)> RecyclingAsync(string name, RecyclingRequest recyclingRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Take an item from your bank and put it in the character's inventory.
        /// </summary>
        /// <param name="name">The name of the character making the withdrawal.</param>
        /// <param name="withdrawBankRequest">The request <see cref="WithdrawBankRequest"/> containing details about the item to be withdrawn.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="BankItemTransaction"/>
        /// and an optional <see cref="WithdrawBankError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(BankItemTransaction result, WithdrawBankError? error)> WithdrawBankAsync(string name, WithdrawBankRequest withdrawBankRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Withdraw gold from your bank.
        /// </summary>
        /// <param name="name">The name of the character making the withdrawal.</param>
        /// <param name="withdrawBankGoldRequest">The request <see cref="WithdrawBankGoldRequest"/> containing the amount of gold to be withdrawn.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="BankGoldTransaction"/>
        /// and an optional <see cref="WithdrawBankGoldError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(BankGoldTransaction result, WithdrawBankGoldError? error)> WithdrawBankGoldAsync(string name, WithdrawBankGoldRequest withdrawBankGoldRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Buy an item at the Grand Exchange on the character's map.
        /// </summary>
        /// <param name="name">The name of the character making the purchase.</param>
        /// <param name="grandExchangeBuyItemRequest">The request <see cref="GrandExchangeBuyItemRequest"/> containing details about the item to be bought.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="GrandExchangeTransactionData"/>
        /// and an optional <see cref="GrandExchangeBuyItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(GrandExchangeTransactionData result, GrandExchangeBuyItemError? error)> GrandExchangeBuyItemAsync(string name, GrandExchangeBuyItemRequest grandExchangeBuyItemRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create sell order at the Grand Exchange on the character's map.
        /// </summary>
        /// <param name="name">The name of the character making the sale.</param>
        /// <param name="grandExchangeCreateSellOrderRequest">The request <see cref="GrandExchangeCreateSellOrderRequest"/> containing details about order to be created.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="GrandExchangeOrderTransaction"/>
        /// and an optional <see cref="GrandExchangeCreateSellOrderError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(GrandExchangeOrderTransaction result, GrandExchangeCreateSellOrderError? error)> GrandExchangeCreateSellOrderAsync(string name, GrandExchangeCreateSellOrderRequest grandExchangeCreateSellOrderRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancel sell order at the Grand Exchange on the character's map.
        /// </summary>
        /// <param name="name">The name of the character making the sale.</param>
        /// <param name="grandExchangeCancelSellOrderRequest">The request <see cref="GrandExchangeCancelSellOrderRequest"/> containing details about order to be canceled.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="GrandExchangeTransactionData"/>
        /// and an optional <see cref="GrandExchangeCancelSellOrderError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(GrandExchangeTransactionData result, GrandExchangeCancelSellOrderError? error)> GrandExchangeCancelSellOrderAsync(string name, GrandExchangeCancelSellOrderRequest grandExchangeCancelSellOrderRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Buy a 20 slots bank expansion.
        /// </summary>
        /// <param name="name">The name of the character purchasing the bank expansion.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="BankExtensionTransaction"/>
        /// and an optional <see cref="BuyBankExpansionError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(BankExtensionTransaction result, BuyBankExpansionError? error)> BuyBankExpansionAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Buy an item from an NPC on the character's map.
        /// </summary>
        /// <param name="name">The name of the character buying the item.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="NpcMerchantTransaction"/>
        /// and an optional <see cref="NpcBuyItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(NpcMerchantTransaction result, NpcBuyItemError? error)> NpcBuyItemAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sell an item from an NPC on the character's map.
        /// </summary>
        /// <param name="name">The name of the character selling the item.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="NpcMerchantTransaction"/>
        /// and an optional <see cref="NpcSellItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(NpcMerchantTransaction result, NpcSellItemError? error)> NpcSellItemAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Accepting a new task.
        /// </summary>
        /// <param name="name">The name of the character accepting the task.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskData"/>
        /// and an optional <see cref="AcceptNewTaskError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskData result, AcceptNewTaskError? error)> AcceptNewTaskAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Complete a task.
        /// </summary>
        /// <param name="name">The name of the character completing the task.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskRewardData"/>
        /// and an optional <see cref="CompleteTaskError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskRewardData result, CompleteTaskError? error)> CompleteTaskAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Exchange 6 tasks coins for a random reward. Rewards are exclusive items or resources.
        /// </summary>
        /// <param name="name">The name of the character exchanging task rewards.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskRewardData"/>
        /// and an optional <see cref="TaskExchangeError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskRewardData result, TaskExchangeError? error)> TaskExchangeAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Trading items with a Tasks Master.
        /// </summary>
        /// <param name="name">The name of the character initiating the trade.</param>
        /// <param name="taskTradeRequest">The request <see cref="TaskTradeRequest"/> containing details about the trade.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskTradeData"/>
        /// and an optional <see cref="TaskTradeError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskTradeData result, TaskTradeError? error)> TaskTradeAsync(string name, TaskTradeRequest taskTradeRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancel a task for 1 tasks coin.
        /// </summary>
        /// <param name="name">The name of the character canceling the task.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskCancelled"/>
        /// and an optional <see cref="TaskCancelledError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskCancelled result, TaskCancelledError? error)> TaskCancelAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Use an item as a consumable.
        /// </summary>
        /// <param name="name">The name of the character using the item.</param>
        /// <param name="useItemRequest">The request <see cref="UseItemRequest"/> containing details about item to be used.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskCancelled"/>
        /// and an optional <see cref="UseItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(UseItem result, UseItemError? error)> UseItemAsync(string name, UseItemRequest useItemRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recovers hit points by resting. (1 second per 5 HP, minimum 3 seconds)
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskCancelled"/>
        /// and an optional <see cref="UseItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(CharacterRestData result, RestError? error)> RestAsync(string name, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Delete an item from your character's inventory.
        /// </summary>
        /// <param name="name">The name of the character deleting the item.</param>
        /// <param name="deleteItemRequest">The request <see cref="DeleteItemRequest"/> containing details about the item to be deleted.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="DeleteItem"/>
        /// and an optional <see cref="DeleteItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(DeleteItem result, DeleteItemError? error)> DeleteItemAsync(string name, DeleteItemRequest deleteItemRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// History of the last 100 actions of all your characters.
        /// </summary>
        /// <param name="allCharactersLogsQuery">The query <see cref="AllCharactersLogsQuery"/> containing the parameters for fetching logs.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="PagedResponse{Log}"/>
        /// and an optional <see cref="GetAllCharactersLogsError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(PagedResponse<Log> result, GetAllCharactersLogsError? error)> GetAllCharactersLogsAsync(AllCharactersLogsQuery allCharactersLogsQuery, CancellationToken cancellationToken = default);

        /// <summary>
        /// List of your characters.
        /// </summary>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a read-only collection of <see cref="Character"/> instances.</returns>
        /// <exception cref="ApiException"></exception>
        Task<IReadOnlyCollection<Character>> GetMyCharactersAsync(CancellationToken cancellationToken = default);
    }
}
