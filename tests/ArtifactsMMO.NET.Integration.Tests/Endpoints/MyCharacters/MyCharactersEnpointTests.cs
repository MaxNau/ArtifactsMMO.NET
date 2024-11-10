using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects.Characters;
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

        [Fact, Priority(10)]
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
