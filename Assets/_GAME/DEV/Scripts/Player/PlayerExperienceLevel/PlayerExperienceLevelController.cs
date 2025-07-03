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
            _currentXp += gainAmount;

            bool leveledup = false;
            
            while (_currentXp >= XPToNextLevel())
            {
                _currentXp -= XPToNextLevel();
                _currentXpLevel++;
                
                leveledup = true;
                
                var rewards = _levelProgressionSO.GetRewardsForLevel(_currentXpLevel);
                if (rewards != null)
                {
                    foreach (var reward in rewards)
                    {
                        reward.Unlock();
                    }
                }
            }
            
            InvokeLevelUpEvents();
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