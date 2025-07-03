using UnityEngine;

[CreateAssetMenu(fileName = "UnlockableReward", menuName = "Scriptable Objects/UnlockableRewardSO")]
public class UnlockableRewardSO : ScriptableObject
{
    public string rewardName;
    public Sprite icon;
    public string description;

    public void Unlock()
    {
        Debug.Log("Unlocked" + rewardName);
        // Logic to grant the reward can be added in future
    }
}