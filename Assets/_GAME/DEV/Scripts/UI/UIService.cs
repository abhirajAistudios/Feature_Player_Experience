using System.Collections;
using PlayerExperience.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience
{
    public class UIService : MonoBehaviour
    {
        private EventService _eventService;
        public Slider _slider;
        public TextMeshProUGUI _levelText;
        public TextMeshProUGUI _xpText;
        public TextMeshProUGUI _xpGainedPopUp;
        public TextMeshProUGUI _levelUpPopUp;

        public void UIStart()
        {
            _eventService.OnIncreaseOfXp.AddListener(IncreaseSliderValue);
            _eventService.RefreshExperience.AddListener(ResetSliderValue);
            _eventService.RefreshExperienceValue.AddListener(ResetSliderMaxValue);
            _eventService.OnLevelUp.AddListener(ResetLevelText);
            _eventService.OnIncreaseOfXp.AddListener(Show);
        }

        public void InjectDependecies(EventService eventService)
        {
            _eventService  = eventService;
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
            StartCoroutine(LevelUpPopUp(value));
        }
        
        private void Show(int value)
        {
            StartCoroutine(ShowXpPopUp(value));
        }

        private IEnumerator ShowXpPopUp(int value)
        {
            _xpGainedPopUp.text = "+" + value + " XP";
            _xpGainedPopUp.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            _xpGainedPopUp.gameObject.SetActive(false);
        }

        private IEnumerator LevelUpPopUp(int value)
        {
            _levelUpPopUp.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            _levelUpPopUp.gameObject.SetActive(false);
        }
    }
}