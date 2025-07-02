using System;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerExperienceLevelController : MonoBehaviour
    {
        private int _currentXpLevel;
        private int _currentXp;
        private const int XpToNextLevel = 100;

        private int _xpGain;

        private void Update()
        {
            CheckForLevelUp();
        }

        private void IncreaseXp(int gainAmount) => _xpGain += gainAmount;

        private void CheckForLevelUp()
        {
            if (_xpGain >= XpToNextLevel)
            {
                _currentXpLevel++;
            }
        }
    }
}
