namespace PlayerExperience
{
    [System.Serializable]
    public class LevelData
    {
        public int _level;
        public int _xpRequired;
        public UnlockableRewardSO[] rewards;
    }
}