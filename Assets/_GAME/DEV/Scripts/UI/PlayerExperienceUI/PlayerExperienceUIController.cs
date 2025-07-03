using UnityEngine;

namespace PlayerExperience.UI
{
    public class PlayerExperienceUIController
    {
        private PlayerExperienceUIView _playerExperienceUIView;
        private UIService _uiService;
        
        public PlayerExperienceUIController(PlayerExperienceUIView playerExperienceUIView, UIService uiService)
        {
            _playerExperienceUIView = playerExperienceUIView;
            _uiService = uiService;
            _playerExperienceUIView.SetController(this);
            AddListensers();
        }

        public void AddListensers()
        {
           _uiService._eventService.OnIncreaseOfXp.AddListener(IncreaseSliderValue);
           _uiService._eventService.RefreshExperience.AddListener(ResetSliderValue);
           _uiService._eventService.RefreshExperienceValue.AddListener(ResetSliderMaxValue);
           _uiService._eventService.OnLevelUp.AddListener(ResetLevelText);
           _uiService._eventService.OnIncreaseOfXp.AddListener(Show);
        }
        
        private void IncreaseSliderValue(int value)
        {
            _playerExperienceUIView._experienceFiller.value += value;
            _playerExperienceUIView._xpText.text = _playerExperienceUIView._experienceFiller.value + " / "  + _playerExperienceUIView._experienceFiller.maxValue;
        }

        private void ResetSliderValue()
        {
            _playerExperienceUIView._experienceFiller.value = 0;
            _playerExperienceUIView._xpText.text = _playerExperienceUIView._experienceFiller.value + " / "  + _playerExperienceUIView._experienceFiller.maxValue;
        }

        private void ResetSliderMaxValue(int value)
        {
            _playerExperienceUIView._experienceFiller.maxValue = value;
        }

        private void ResetLevelText(int value)
        {
            _playerExperienceUIView._levelText.text = "Level " + value;
           // StartCoroutine(LevelUpPopUp(value));
        }
        
        private void Show(int value)
        {
            //StartCoroutine(ShowXpPopUp(value));
        }

       // private IEnumerator ShowXpPopUp(int value)
       // {
       //     _xpGainedPopUp.text = "+" + value + " XP";
       //     _xpGainedPopUp.gameObject.SetActive(true);
       //     yield return new WaitForSeconds(1);
       //     _xpGainedPopUp.gameObject.SetActive(false);
       // }
//
       // private IEnumerator LevelUpPopUp(int value)
       // {
       //     _levelUpPopUp.gameObject.SetActive(true);
       //     yield return new WaitForSeconds(1);
       //     _levelUpPopUp.gameObject.SetActive(false);
       // }
    }
}