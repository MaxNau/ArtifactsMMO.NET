# ArtifactsMMO.NET
.NET client for the Artifacts MMO - https://artifactsmmo.com/

**Version:** 2.3

Artifacts is an API-based MMO game where you can manage up to 5 characters to explore, fight, gather resources, craft items, and much more.

- **Website:** [artifactsmmo.com](https://artifactsmmo.com/)
- **Documentation:** [API Documentation](https://docs.artifactsmmo.com/)
- **OpenAPI Spec:** [OpenAPI Specification](https://api.artifactsmmo.com/openapi.json)

## Overview

This fully implemented and well documented .NET client provides a convenient way to interact with the Artifacts API.

Error Handling

The client includes built-in error handling for various scenarios, such as:

- Invalid requests
- Error API responses realted to actions in game

For detailed error information, check the ApiError object returned in case of unexpected exceptions.

## Usage

Core client:

```csharp
// Using ArtifactsMMO.NET.DependencyInjection.Extensions
var serviceProvider = new ServiceCollection()
.AddArtifactsMMOClient("<your token>")
.BuildServiceProvider();

// resolved as singleton instance
var client = serviceProvider.GetRequiredService<IArtifactsMMOClient>();
// For non-DI
// IArtifactsMMOClient client = new ArtifactsMMOClient(new HttpClient(), "<your token>");

var serverStatus = await client.GetStatusAsync();

// Get your character
var (character, error) = await client.Characters.GetAsync("<your character name>");

// Check if there any error
if (error == null)
{
    // Move your character
    var (characterMoveData, moveError) = await client.MyCharacters.MoveAsync(character.Name, new MoveRequest(1, 1));

    // Check for error
    if (moveError == null)
    {
        var (fightData, fightError) = await client.MyCharacters.FightAsync(characterMoveData.Character.Name);
    }
    else
    {
        // Handle error
        switch (moveError.Value)
        {
            // Character is in cooldown
            case MoveError.CharacterInCooldown:
                // Wait for cooldown expiration
                await Task.Delay((characterMoveData.Cooldown.StartedAt - characterMoveData.Cooldown.Expiration).Microseconds);
                // Repeat the action
                await client.MyCharacters.MoveAsync(character.Name, new MoveRequest(1, 1));
                break;

        }
    }
}
else
{
    if (error == GetCharacterError.CharacterNotFound)
    {
        // Create new character
        await client.Characters.CreateAsync(new CreateCharacterRequest("<your desired character name>", SkinCode.Men3));
    }
}
```

## Contributing

Contributions are welcome! If you encounter any issues or want to add features, feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

## Support

For issues, questions, or feature requests, please open an issue on GitHub.
