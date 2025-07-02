using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience
{
    public class UIService : MonoBehaviour
    {
        public Slider _slider;
        public TextMeshProUGUI _levelText;
        public TextMeshProUGUI _xpText;

        private void Start()
        {
            EventService.OnIncreaseOfXp.AddListener(IncreaseSliderValue);
            EventService.RefreshExperience.AddListener(ResetSliderValue);
            EventService.RefreshExperienceValue.AddListener(ResetSliderMaxValue);
            EventService.OnLevelUp.AddListener(ResetLevelText);
        }

        private void IncreaseSliderValue(int value)
        {
            _slider.value += value;
            _xpText.text = _slider.value + " / "  + _slider.maxValue;
        }

        private void ResetSliderValue()
        {
            _slider.value = 0;
            _xpText.text = _slider.value + " / "  + _slider.maxValue;
        }

        private void ResetSliderMaxValue(int value)
        {
            _slider.maxValue = value;
        }

        private void ResetLevelText(int value)
        {
            _levelText.text = "Level " + value;
        }
    }
}