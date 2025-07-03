using PlayerExperience.Events;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController
    {
        private EventService _eventService;
        private LevelProgressionSO _levelProgressionSO;
        
        private int _currentXpLevel = 1;
        private int _currentXp;
        private int _initialXp = 0;

        private bool _leveledUp;
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

        private void GainXp(int gainAmount)
        {
            if (_currentXpLevel == _levelProgressionSO.MaxLevel)
            {
                int maxXp = XPToNextLevel();

                if (_currentXp < maxXp)
                {
                    _currentXp += gainAmount;
                    _currentXp = Mathf.Min(_currentXp, maxXp);
                    Debug.Log($"[XP] At max level {_currentXpLevel}, XP: {_currentXp}/{maxXp}");
                    
                    if (_currentXp == maxXp)
                    {
                        Debug.Log("[XP] Max level and max XP reached!");
                    }

                    InvokeLevelUpEvents();
                }
                else
                {
                    Debug.Log($"[XP] Already at max level with full XP.");
                }
                return;
            }
            
            _currentXp += gainAmount;

            _leveledUp = false;
            
            while (_currentXp >= XPToNextLevel())
            {
                LevelUp();
                
               if (_currentXpLevel >= _levelProgressionSO.MaxLevel)
               {
                   _currentXp = 0; // optionally reset to 0
                   Debug.Log($"[XP] Reached max level {_currentXpLevel}!");
                   return;
               }
            }
            
            InvokeLevelUpEvents();
        }

        private void LevelUp()
        {
            while (_currentXp >= XPToNextLevel())
            {
                _currentXp -= XPToNextLevel();
                _currentXpLevel++;
            }
                
            _leveledUp = true;
                
            var rewards = _levelProgressionSO.GetRewardsForLevel(_currentXpLevel);
            if (rewards != null)
            {
                foreach (var reward in rewards)
                {
                    reward.Unlock();
                }
            }
        }
        private void InvokeLevelUpEvents()
        {
            _eventService.ResetLevel.InvokeEvent(_currentXpLevel);
            _eventService.ResetExperience.InvokeEvent(_currentXp);
            _eventService.ResetMaxExperienceValue.InvokeEvent(XPToNextLevel());
        }
        public int XPToNextLevel() => _levelProgressionSO.GetXPForLevel(_currentXpLevel);
    }
}