# Player XP and Level Progression System
==============================
Player XP & Level Progression System
==============================

This system manages player experience (XP), leveling, UI updates, and reward distribution.
It follows MVC principles, the Observer Pattern, and uses ScriptableObject-based architecture
to separate data from logic and UI.

------------------------------
1. PlayerExperienceLevelController
------------------------------
Type: Logic Controller

Responsibilities:
- Manages current XP and player level
- Handles XP gain and level-up logic
- Grants rewards on level-up
- Emits events to update the UI

Key Methods:
- GainXp(int gainAmount): Adds XP and handles level progression
- LevelUp(): Increments level and unlocks rewards
- XPToNextLevel(): Returns XP required for the next level
- InvokeLevelUpEvents(): Fires events to refresh the UI

------------------------------
2. PlayerExperienceUIController
------------------------------
Type: UI Controller

Responsibilities:
- Listens to game events
- Updates UI elements like XP bar and level text
- Shows XP and level-up popups via the UI view

Key Methods:
- AddListensers(): Subscribes to XP-related events
- ResetSliderValue(int): Updates the XP progress bar
- ResetSliderMaxValue(int): Updates XP required for the next level
- ResetLevelText(int): Updates level display text

------------------------------
3. PlayerExperienceUIView
------------------------------
Type: MonoBehaviour (UI View)

Responsibilities:
- Shows visual feedback for XP gain and level-up
- Spawns animated popups using LeanTween

Key Methods:
- ShowXpPopUp(int): Displays an animated XP popup
- ShowLevelUpPopUp(): Displays a level-up popup

------------------------------
4. LevelProgressionSO
------------------------------
Type: ScriptableObject

Responsibilities:
- Stores per-level XP requirements and rewards
- Defines the max level

Key Properties/Methods:
- MaxLevel: Total number of defined levels
- GetXPForLevel(int): Returns XP needed for a given level
- GetRewardsForLevel(int): Returns rewards assigned to a level

------------------------------
5. UnlockableRewardSO
------------------------------
Type: ScriptableObject

Responsibilities:
- Stores reward data (name, icon, description)
- Can be used as a level-up reward
- Unlock() method prints a debug message and can be extended to apply rewards

Example Fields:
- rewardName: string
- icon: Sprite
- description: string

------------------------------
Testing Tip:
------------------------------
To test XP gain during development, call:

    eventService.OnGainXp.InvokeEvent(xpAmount);

For example, you can bind it to a key:

    if (Input.GetKeyDown(KeyCode.Space))
    {
        eventService.OnGainXp.InvokeEvent(20);
    }

------------------------------
Dependencies:
------------------------------
- TextMeshPro: For UI text
- LeanTween: For animating popups (available on Unity Asset Store)

------------------------------
Notes:
------------------------------
- All components follow a modular design for scalability and reusability.
- XP system can be extended to include XP boosters, quest integration, or skill trees.


