using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Requests
{
    [JsonDerivedType(typeof(MoveRequest))]
    [JsonDerivedType(typeof(CraftingRequest))]
    [JsonDerivedType(typeof(CreateAccountRequest))]
    [JsonDerivedType(typeof(CreateCharacterRequest))]
    [JsonDerivedType(typeof(DeleteCharacterRequest))]
    [JsonDerivedType(typeof(DeleteItemRequest))]
    [JsonDerivedType(typeof(DepositBankGoldRequest))]
    [JsonDerivedType(typeof(DepositBankRequest))]
    [JsonDerivedType(typeof(EquipItemRequest))]
    [JsonDerivedType(typeof(UnequipItemReguest))]
    [JsonDerivedType(typeof(GrandExchangetemRequest))]
    [JsonDerivedType(typeof(PasswordResetRequest))]
    [JsonDerivedType(typeof(RecyclingRequest))]
    [JsonDerivedType(typeof(TaskTradeRequest))]
    [JsonDerivedType(typeof(WithdrawBankGoldRequest))]
    [JsonDerivedType(typeof(WithdrawBankRequest))]
    internal interface IRequest
    {
    }
}
