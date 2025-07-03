using PlayerExperience.Events;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController
    {
        private EventService _eventService;
        private LevelProgressionSO _levelProgressionSO;
        
        private int _currentXpLevel = 1;
        private int _currentXp = 0;

        public PlayerExperienceLevelController(LevelProgressionSO levelProgressionSO)
        {
            _levelProgressionSO = levelProgressionSO;
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
            
            while (_currentXp >= XPToNextLevel())
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            _currentXp -= XPToNextLevel();
            
            var rewards = _levelProgressionSO.GetRewardsForLevel(_currentXpLevel);
            if (rewards != null)
            {
                foreach (var reward in rewards)
                {
                    reward.Unlock();
                }
            }
            _currentXpLevel++;
            
            InvokeLevelUpEvents();
        }

        private void InvokeLevelUpEvents()
        {
            _eventService.ResetLevel.InvokeEvent(_currentXpLevel);
            _eventService.ResetExperienceValue.InvokeEvent(XPToNextLevel());
            _eventService.ResetExperience.InvokeEvent();
        }
        public int XPToNextLevel() => _levelProgressionSO.GetXPForLevel(_currentXpLevel);
    }
}