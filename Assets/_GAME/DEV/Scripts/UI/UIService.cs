using System.Collections;
using PlayerExperience.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience.UI
{
    public class UIService : MonoBehaviour
    {
        public EventService _eventService {  get; private set; }
        
        private PlayerExperienceUIController _playerExperienceUIController;

        public PlayerExperienceUIView _playerExperienceUIView;
        public void UIStart()
        {
            _playerExperienceUIController = new PlayerExperienceUIController(_playerExperienceUIView, this);
        }
        public void InjectDependecies(EventService eventService)
        {
            _eventService  = eventService;
            _playerExperienceUIController.AddListensers();
        }
    }
}