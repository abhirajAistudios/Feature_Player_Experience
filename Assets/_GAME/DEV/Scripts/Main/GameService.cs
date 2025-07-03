using PlayerExperience.Events;
using PlayerExperience.UI;
using UnityEngine;

namespace PlayerExperience
{
    public class GameService : MonoBehaviour
    {
        public EventService EventService { get; private set; }
        public PlayerExperienceLevelController PlayerExperience { get; private set; }
        
        [SerializeField]private UIService _uiService;
        public UIService UIService => _uiService;

        private void Awake()
        {
            InitializeServices();
            InjectDependecies();
        }

        private void InitializeServices()
        {
            EventService = new EventService();
            PlayerExperience = new PlayerExperienceLevelController();
            _uiService.UIStart();
        }

        private void InjectDependecies()
        {
            PlayerExperience.InjectDependecies(EventService);
            _uiService.InjectDependecies(EventService);
        }
    }
}
