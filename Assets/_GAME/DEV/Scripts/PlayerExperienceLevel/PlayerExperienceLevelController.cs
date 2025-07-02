using System;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController : MonoBehaviour
    {
        public LevelProgressionSO levelProgressionSO;
        private int _currentXpLevel = 1;
        private int _currentXp = 0;

        private void Start()
        {
            EventService.OnIncreaseOfXp.AddListener(GainXp);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EventService.OnIncreaseOfXp.InvokeEvent(20);
                Debug.Log(XPToNextLevel());
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
            
            EventService.OnLevelUp.InvokeEvent(_currentXpLevel);
            EventService.RefreshExperienceValue.InvokeEvent(XPToNextLevel());
            EventService.RefreshExperience.InvokeEvent();
            Debug.Log(_currentXpLevel);
        }

        public int XPToNextLevel() => levelProgressionSO.GetXPForLevel(_currentXpLevel);
    }
}
