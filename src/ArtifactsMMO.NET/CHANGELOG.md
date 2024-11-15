# Changelog

All notable changes to this project will be documented in this file.

## [3.0.5]

### Fixed
- FightResult Lose value changed to Loss

## [3.0.4]

### Fixed
- Event => fixed Content property name and added missing Maps property
- Character/Account leaderboard => added missing properties
- Item => added missing Tradeable property
- ActiveEvent => added missing Code property
- Fixed issue with queries containing enums as search parameters
- Fixed issue with newly added requests
- [internal] changes for easier testing

### Removed
- SimpleTaskReward
- ICharacters.GetAsync(CharactersQuery charactersQuery, CancellationToken cancellationToken);

## [3.0.3]

### Fixed
- Fix missing enum values for ItemType and GatheringSkill

## [3.0.2]

### Fixed
- Fix item type enum values

## [3.0.1]

### Fixed
- Fixed cooldown reason enum values

## [3.0.0] - 2024-11-09

### Added
- [internal] Added changelog
- [internal] Added Unit Tests for ArtifactsMMO.NET
- [internal] Started to add integration tests
- CreateAccountRequestValidator - Added Email validation
- New skill - Alchemy.
- New endpoints:
	- **MyCharacters**
		- UseItemAsync - to use consumable items.
		- RestAsync - to recover health without consumables (1s/10HP, minimum 3s).
		- GrandExchangeCreateSellOrderAsync - to create sales orders.
		- GrandExchangeCancelSellOrderAsync - to cancel a sales order.
	- **MyAccount**
		- GetGrandExchangeSellOrdersAsync - to view your current sales orders.
		- GetGrandExchangeSellHistoryAsync - to view your sales history.
	- **Accounts**
		- GetAccountAsync - get account details by account name
		- GetAccountAchievementsAsync - get account achievements
	- **Events**
		- GetAllAsync - get all events
		- GetActiveAsync - get active events
	- **GrandExchange**
		- GetSellHistoryAsync - get sells history
		- GetSellOrdersAsync - get sell orders
		- GetOrderAsync - get order detils
	- **Leaderboard**
		- GetAsync - accounts leaderboards

- Added new properties to Characte: 
	- MaxHp
	- Account
	- AlchemyLevel
	- AlchemyXp
	- AlchemyMaxXp

### Changed
- CreateAccountRequestValidator - Changed ArgumentException to InvalidRequestParameter
- Renamed properties on character
	- Consumable1Slot -> Utility1Slot
	- Consumable1SlotQuantity -> Utility1SlotQuantity
	- Consumable2Slot -> Utility2Slot
	- Consumable2SlotQuantity -> Utility2SlotQuantity
- **Items**
	- GetAsync - changed return type from ItemDetail to Item

### Fixed
- CreateCharacterRequestValidator - fixed validation order

### Removed
- Removed .Net Framework support
- **Characters**
	- GetAchievementAsync
- **Events**
	- GetAsync
- **GrandExchange**
	- GetAsync

---

## [2.4.1] - 2024-11-03
- [No changelog provided.]

## [2.4.0] - 2024-11-02
- [No changelog provided.]

## [2.3.1] - 2024-10-26
- [No changelog provided.]

## [2.3.0] - 2024-10-26
- [No changelog provided.]