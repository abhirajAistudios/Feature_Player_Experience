using PlayerExperience;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelProgression", menuName = "Scriptable Objects/LevelProgressionSO")]
public class LevelProgressionSO : ScriptableObject
{
    // Array containing level data
    public LevelData[] levels;
    
    // The maximum level is determined by the number of level entries
    public int MaxLevel => levels.Length;

    // Returns the amount of XP required to reach a specific level
    public int GetXPForLevel(int level) => level - 1 < levels.Length ? levels[level - 1]._xpRequired : int.MaxValue;

    // Returns the array of rewards associated with a specific level
    public UnlockableRewardSO[] GetRewardsForLevel(int level) =>
        level - 1 < levels.Length ? levels[level - 1].rewards : null;
}