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
        }

        // Registers listeners to respond to game events
        public void AddListensers()
        {
            // Listen for XP and level changes to update UI elements
           _uiService._eventService.ResetExperience.AddListener(ResetSliderValue);
           _uiService._eventService.ResetMaxExperienceValue.AddListener(ResetSliderMaxValue);
           _uiService._eventService.ResetLevel.AddListener(ResetLevelText);
           
           // Listen for XP gain and level up events to show popups
           _uiService._eventService.OnGainXp.AddListener(_playerExperienceUIView.ShowXpPopUp);
           _uiService._eventService.OnLevelUp.AddListener(_playerExperienceUIView.ShowLevelUpPopUp);
        }

        // Updates the current value of the XP slider and text when XP changes
        private void ResetSliderValue(int  value)
        {
            _playerExperienceUIView._experienceFiller.value = value;
            _playerExperienceUIView._xpText.text = _playerExperienceUIView._experienceFiller.value + " / "  + _playerExperienceUIView._experienceFiller.maxValue;
        }

        // Updates the maximum value of the XP slider (when leveling up)
        private void ResetSliderMaxValue(int value)
        {
            _playerExperienceUIView._experienceFiller.maxValue = value;
        }

        // Updates the level text on the UI 
        private void ResetLevelText(int value)
        {
            _playerExperienceUIView._levelText.text = "Level " + value;
        }
    }
}