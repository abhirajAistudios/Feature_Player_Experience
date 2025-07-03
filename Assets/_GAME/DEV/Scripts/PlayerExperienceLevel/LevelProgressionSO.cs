using PlayerExperience;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelProgression", menuName = "Scriptable Objects/LevelProgressionSO")]
public class LevelProgressionSO : ScriptableObject
{
    public LevelData[] levels;

    public int GetXPForLevel(int level) => level - 1 < levels.Length ? levels[level - 1]._xpRequired : int.MaxValue;

    public UnlockableRewardSO[] GetRewardsForLevel(int level) =>
        level - 1 < levels.Length ? levels[level - 1].rewards : null;
}