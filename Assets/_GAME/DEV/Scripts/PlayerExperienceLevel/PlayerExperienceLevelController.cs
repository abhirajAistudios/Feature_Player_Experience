using PlayerExperience.Events;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController
    {
        private EventService _eventService;
        public LevelProgressionSO levelProgressionSO;
        
        private int _currentXpLevel = 1;
        private int _currentXp = 0;

        public void InjectDependecies(EventService eventService)
        {
            _eventService = eventService;
            SubscribeToEvents();
        }
        private void SubscribeToEvents()
        {
            _eventService.OnIncreaseOfXp.AddListener(GainXp);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _eventService.OnIncreaseOfXp.InvokeEvent(20);
            }
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
            
            var rewards = levelProgressionSO.GetRewardsForLevel(_currentXpLevel);
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
            _eventService.OnLevelUp.InvokeEvent(_currentXpLevel);
            _eventService.RefreshExperienceValue.InvokeEvent(XPToNextLevel());
            _eventService.RefreshExperience.InvokeEvent();
        }
        public int XPToNextLevel() => levelProgressionSO.GetXPForLevel(_currentXpLevel);
    }
}