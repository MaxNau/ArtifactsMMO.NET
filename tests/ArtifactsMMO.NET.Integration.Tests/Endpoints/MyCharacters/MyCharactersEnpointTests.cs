using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Priority;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.MyCharacters
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class MyCharactersEnpointTests : IClassFixture<CharacterTestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        private readonly CharacterTestFixture _characterTestFixture;

        public MyCharactersEnpointTests(CharacterTestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;

            _characterTestFixture = fixture;
        }

        [Fact, Priority(1)]
        public async Task CreateCharacter_ShouldSucceed()
        {
            var (character, error) = await _client.Characters.GetAsync(_characterTestFixture.CharacterName);

            if (error == GetCharacterError.CharacterNotFound)
            {
                var (createdCharacter, createError) = await _client.Characters.CreateAsync(new CreateCharacterRequest(_characterTestFixture.CharacterName, SkinCode.Men1));
                
                Assert.Null(createError);
            }
        }

        [Fact, Priority(2)]
        public async Task CharacterCanMove()
        {
            var (character, error) = await _client.MyCharacters.MoveAsync(
                _characterTestFixture.CharacterName,
                new MoveRequest(0, 1));

            Assert.Null(error);
            Assert.NotNull(character);

            await WaitAsync(character.Cooldown.StartedAt, character.Cooldown.Expiration);
        }

        [Fact, Priority(3)]
        public async Task CharacterCanRest()
        {
            var (character, error) = await _client.MyCharacters.RestAsync(
                _characterTestFixture.CharacterName);

            Assert.Null(error);
            Assert.NotNull(character);

            await WaitAsync(character.Cooldown.StartedAt, character.Cooldown.Expiration);
        }

        [Fact, Priority(4)]
        public async Task CharacterCanAcceptTask()
        {
            var taskMasterLocations = await _client.Maps.GetAsync(new MapsQuery(contentType: MapContentType.TasksMaster));
            var taskMasterMap = taskMasterLocations.Data.First();

            var moveData = await _client.MyCharacters.MoveAsync(
                _characterTestFixture.CharacterName,
                new MoveRequest(taskMasterMap.X, taskMasterMap.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            var taskData = await _client.MyCharacters.AcceptNewTaskAsync(_characterTestFixture.CharacterName);

            await WaitAsync(taskData.result.Cooldown.StartedAt, taskData.result.Cooldown.Expiration);
        }

        [Fact, Priority(5)]
        public async Task CharacterCanGather()
        {
            var minLevelResourceNodes = await _client.Resources.GetAsync(new ResourcesQuery(maxLevel: 1, skill: GatheringSkill.Mining));
            var minLevelResourceNode = minLevelResourceNodes.Data.First();
            
            var resourceMaps = await _client.Maps.GetAsync(new MapsQuery(contentCode: minLevelResourceNode.Code, contentType: MapContentType.Resource));
            var resourceMap = resourceMaps.Data.First();

            var moveData = await _client.MyCharacters.MoveAsync(
                _characterTestFixture.CharacterName,
                new MoveRequest(resourceMap.X, resourceMap.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            var (character, error) = await _client.MyCharacters.GatheringAsync(
                _characterTestFixture.CharacterName);

            Assert.Null(error);
            Assert.NotNull(character);

            await WaitAsync(character.Cooldown.StartedAt, character.Cooldown.Expiration);
        }

        [Fact, Priority(6)]
        public async Task CharacterCanFight()
        {
            var minLevelMonsters = await _client.Monsters.GetAsync(new MonstersQuery(maxLevel: 1));
            var minLevelMonster = minLevelMonsters.Data.First();

            var monsterLocations = await _client.Maps.GetAsync(new MapsQuery(contentCode: minLevelMonster.Code));
            var monsterLocation = monsterLocations.Data.First();

            var moveData = await _client.MyCharacters.MoveAsync(
                _characterTestFixture.CharacterName,
                new MoveRequest(monsterLocation.X, monsterLocation.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            var fightData = await _client.MyCharacters.FightAsync(_characterTestFixture.CharacterName);

            await WaitAsync(fightData.result.Cooldown.StartedAt, fightData.result.Cooldown.Expiration);

            var restData = await _client.MyCharacters.RestAsync(_characterTestFixture.CharacterName);

            await WaitAsync(restData.result.Cooldown.StartedAt, restData.result.Cooldown.Expiration);
        }

        [Fact, Priority(7)]
        public async Task CharacterCanDeleteItem()
        {
            var character = await _client.Characters.GetAsync(_characterTestFixture.CharacterName);

            while (!character.result.Inventory.Any(slot => slot.Quantity > 0))
            {
                var fightData = await _client.MyCharacters.FightAsync(_characterTestFixture.CharacterName);

                await WaitAsync(fightData.result.Cooldown.StartedAt, fightData.result.Cooldown.Expiration);

                var restData = await _client.MyCharacters.RestAsync(_characterTestFixture.CharacterName);

                await WaitAsync(restData.result.Cooldown.StartedAt, restData.result.Cooldown.Expiration);

                character.result = restData.result.Character;
            }

            var itemSlot = character.result.Inventory.First(slot => slot.Quantity > 0);
            
            var deleteItemData = await _client.MyCharacters.DeleteItemAsync(_characterTestFixture.CharacterName,
                new DeleteItemRequest(itemSlot.Code, 1));

            await WaitAsync(deleteItemData.result.Cooldown.StartedAt, deleteItemData.result.Cooldown.Expiration);
        }

        [Fact, Priority(8)]
        public async Task CharacterCanCraft()
        {
            var fishResources = await _client.Resources.GetAsync(
                new ResourcesQuery(skill: GatheringSkill.Fishing, maxLevel: 1));
            var fishResource = fishResources.Data.First();

            var fishLocations = await _client.Maps.GetAsync(
                new MapsQuery(fishResource.Code));

            var fishLocation = fishLocations.Data.First();

            var moveData = await _client.MyCharacters.MoveAsync(
               _characterTestFixture.CharacterName,
               new MoveRequest(fishLocation.X, fishLocation.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            // catch 3 fish to use it in further tests
            var fishCount = 0;
            while (fishCount != 3)
            {
                var gatherData = await _client.MyCharacters.GatheringAsync(_characterTestFixture.CharacterName);

                await WaitAsync(gatherData.result.Cooldown.StartedAt, gatherData.result.Cooldown.Expiration);
                fishCount++;
            }

            var cookingWorkshopLocations = await _client.Maps.GetAsync(new MapsQuery
            (
                contentCode: CraftSkill.Cooking.ToString().ToLower(),
                contentType: MapContentType.Workshop
            ));

            var cookingWorkshopLocation = cookingWorkshopLocations.Data.First();

            moveData = await _client.MyCharacters.MoveAsync(
               _characterTestFixture.CharacterName,
               new MoveRequest(cookingWorkshopLocation.X, cookingWorkshopLocation.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            var itemsToCraft = await _client.Items.GetAsync(new ItemsQuery
            (
                craftSkill: CraftSkill.Cooking,
                craftMaterial: fishResource.Drops.First(x => x.Rate == 1).Code
            ));

            var itemToCraft = itemsToCraft.Data.First();

            var craftData = await _client.MyCharacters.CraftingAsync(_characterTestFixture.CharacterName,
                new CraftingRequest(itemToCraft.Code));

            await WaitAsync(craftData.result.Cooldown.StartedAt, craftData.result.Cooldown.Expiration);
        }

        [Fact, Priority(9)]
        public async Task CharacterCanDepositItem()
        {
            var bankLocations = await _client.Maps.GetAsync(
                new MapsQuery(
                    contentType: MapContentType.Bank
                    ));

            var bankLocation = bankLocations.Data.First();

            var moveData = await _client.MyCharacters.MoveAsync(
                _characterTestFixture.CharacterName,
                new MoveRequest(bankLocation.X, bankLocation.Y));

            await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

            var depositData = await _client.MyCharacters.DepositBankAsync(_characterTestFixture.CharacterName,
                new DepositBankRequest(
                    "cooked_gudgeon",
                    1
                    ));

            await WaitAsync(depositData.result.Cooldown.StartedAt, depositData.result.Cooldown.Expiration);

        }

        [Fact, Priority(10)]
        public async Task CharacterCanWithdrawItem()
        {
            var withdrawData = await _client.MyCharacters.WithdrawBankAsync(_characterTestFixture.CharacterName,
             new WithdrawBankRequest(
                 "cooked_gudgeon",
                 1
                 ));

            await WaitAsync(withdrawData.result.Cooldown.StartedAt, withdrawData.result.Cooldown.Expiration);
        }

        [Fact, Priority(11)]
        public async Task CharacterCanUseItem()
        {
            var useItemData = await _client.MyCharacters.UseItemAsync(_characterTestFixture.CharacterName,
                new UseItemRequest(
                    code: "cooked_gudgeon",
                    quantity: 1
                    ));

            await WaitAsync(useItemData.result.Cooldown.StartedAt, useItemData.result.Cooldown.Expiration);
        }

        //[Fact, Priority(12)]
        //public async Task CharacterCanCreateAndCancelSellOrder()
        //{
        //    var geLocations = await _client.Maps.GetAsync(
        //        new MapsQuery(
        //        contentType: MapContentType.GrandExchange
        //    ));

        //    var geLocation = geLocations.Data.First();

        //    var moveData = await _client.MyCharacters.MoveAsync(
        //        _characterTestFixture.CharacterName,
        //        new MoveRequest(geLocation.X, geLocation.Y));

        //    await WaitAsync(moveData.result.Cooldown.StartedAt, moveData.result.Cooldown.Expiration);

        //    var sellData = await _client.MyCharacters.GrandExchangeCreateSellOrderAsync(_characterTestFixture.CharacterName,
        //        new GrandExchangeCreateSellOrderRequest
        //        (
        //            "gudgeon",
        //            1,
        //            1
        //        ));

        //    await WaitAsync(sellData.result.Cooldown.StartedAt, sellData.result.Cooldown.Expiration);

        //    var cancellOrderData = await _client.MyCharacters.GrandExchangeCancelSellOrderAsync(_characterTestFixture.CharacterName,
        //        new GrandExchangeCancelSellOrderRequest
        //        (
        //            sellData.result.Order.Id
        //        ));

        //    await WaitAsync(cancellOrderData.result.Cooldown.StartedAt, cancellOrderData.result.Cooldown.Expiration);
        //}

        [Fact, Priority(99)]
        public async Task DeleteCharacter_ShouldSucceed()
        {
            var (character, error) = await _client.Characters.DeleteAsync(new DeleteCharacterRequest(_characterTestFixture.CharacterName));
            Assert.True(true);
        }


        private async Task WaitAsync(DateTimeOffset start, DateTimeOffset end)
        {
            await Task.Delay(end - start);
        }
    }
}
