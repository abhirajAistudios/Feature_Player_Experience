using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience
{
    public class PlayerExperiienceUI : MonoBehaviour
    {
        public Slider _slider;

        private void Start()
        {
            EventService.OnIncreaseOfXp.AddListener(IncreaseValue);
            EventService.RefreshExperience.AddListener(ResetValue);
            EventService.RefreshExperienceValue.AddListener(ResetMaxValue);
        }

        private void IncreaseValue(int value)
        {
            _slider.value += value;
        }

        private void ResetValue()
        {
            _slider.value = 0;
        }

        private void ResetMaxValue(int value)
        {
            _slider.maxValue = value;
        }
    }
}
