using PlayerExperience.Events;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController
    {
        // Dependencies
        private EventService _eventService;
        private LevelProgressionSO _levelProgressionSO;
        
        // XP and level tracking
        private int _currentXpLevel = 1;
        private int _currentXp;
        private int _initialXp = 0;
        private bool _reachedMaxLevel;
        
        public PlayerExperienceLevelController(LevelProgressionSO levelProgressionSO)
        {
            _levelProgressionSO = levelProgressionSO;
            _currentXp = _initialXp;
        }
        public void InjectDependecies(EventService eventService)
        {
            _eventService = eventService;
            SubscribeToEvents();
        }
        private void SubscribeToEvents()
        {
            _eventService.OnGainXp.AddListener(GainXp);
        }

        // Handles XP gain and checks for level-up conditions
        private void GainXp(int gainAmount)
        {
            // If player is at max level, only allow filling XP bar up to max
            if (_currentXpLevel == _levelProgressionSO.MaxLevel)
            {
                int maxXp = XPToNextLevel();

                if (_currentXp < maxXp)
                {
                    _currentXp += gainAmount;
                    _currentXp = Mathf.Min(_currentXp, maxXp); // Cap XP at max value
                    InvokeLevelUpEvents();
                    
                }else if (_currentXp == maxXp && !_reachedMaxLevel)
                {
                    _eventService.OnLevelUp.InvokeEvent();  // If XP bar is already full and player hasn't been flagged max yet
                    _reachedMaxLevel = true;
                }
                return;
            }
            
            _currentXp += gainAmount;
            
            // While there's enough XP to level up
            while (_currentXp >= XPToNextLevel())
            {
                LevelUp();
            }
            
            InvokeLevelUpEvents();
        }

        // Handles leveling up the player and granting rewards
        private void LevelUp()
        {
            // Loop in case XP is enough to skip multiple levels
            while (_currentXp >= XPToNextLevel())
            {
                _currentXp -= XPToNextLevel();
                _currentXpLevel++;
            }
            
            // Get and unlock rewards for new level
            var rewards = _levelProgressionSO.GetRewardsForLevel(_currentXpLevel);
            if (rewards != null)
            {
                foreach (var reward in rewards)
                {
                    reward.Unlock();
                }
            }
            
            // If max level reached, reset XP to 0
            if (_currentXpLevel >= _levelProgressionSO.MaxLevel)
            {
                _currentXp = 0;
            }
            
            _eventService.OnLevelUp.InvokeEvent();
        }
        
        // Invokes various event callbacks related to XP and level UI/state
        private void InvokeLevelUpEvents()
        {
            _eventService.ResetLevel.InvokeEvent(_currentXpLevel);
            _eventService.ResetExperience.InvokeEvent(_currentXp);
            _eventService.ResetMaxExperienceValue.InvokeEvent(XPToNextLevel());
        }
        
        // Helper to get required XP for the next level
        public int XPToNextLevel() => _levelProgressionSO.GetXPForLevel(_currentXpLevel);
    }
}