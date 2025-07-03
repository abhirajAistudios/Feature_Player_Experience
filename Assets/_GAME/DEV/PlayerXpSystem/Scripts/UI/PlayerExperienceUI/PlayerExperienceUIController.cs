namespace PlayerExperience.UI
{
    public class PlayerExperienceUIController
    {
        private PlayerExperienceUIView _playerExperienceUIView;
        private UIService _uiService;

        private int _initialValue = 0;
        
        public PlayerExperienceUIController(PlayerExperienceUIView playerExperienceUIView, UIService uiService)
        {
            _playerExperienceUIView = playerExperienceUIView;
            _uiService = uiService;
            _playerExperienceUIView.SetController(this);
        }

        public void AddListensers()
        {
           _uiService._eventService.ResetExperience.AddListener(ResetSliderValue);
           _uiService._eventService.ResetMaxExperienceValue.AddListener(ResetSliderMaxValue);
           _uiService._eventService.ResetLevel.AddListener(ResetLevelText);
        }

        private void ResetSliderValue(int  value)
        {
            _playerExperienceUIView._experienceFiller.value = value;
            _playerExperienceUIView._xpText.text = _playerExperienceUIView._experienceFiller.value + " / "  + _playerExperienceUIView._experienceFiller.maxValue;
            _playerExperienceUIView.ShowXpPopUp(value,true);
        }

        private void ResetSliderMaxValue(int value)
        {
            _playerExperienceUIView._experienceFiller.maxValue = value;
        }

        private void ResetLevelText(int value)
        {
            _playerExperienceUIView._levelText.text = "Level " + value;
            _playerExperienceUIView.ShowLevelUpPopUp();
        }
        
        
    }
}