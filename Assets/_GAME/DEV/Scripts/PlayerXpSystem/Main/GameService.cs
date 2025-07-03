using PlayerExperience.Events;
using PlayerExperience.UI;
using UnityEngine;

namespace PlayerExperience
{
    public class GameService : MonoBehaviour
    {
        public EventService EventService { get; private set; }
        public PlayerExperienceLevelController PlayerExperience { get; private set; }
        
        public PlayerController PlayerController { get; private set; }
        
        [SerializeField]private UIService _uiService;
        public UIService UIService => _uiService;

        [SerializeField]private PlayerView _playerView;
        [SerializeField]private LevelProgressionSO _levelProgressionSO;
        private void Awake()
        {
            InitializeServices();
            InjectDependecies();
        }

        private void InitializeServices()
        {
            EventService = new EventService();
            PlayerController = new PlayerController(_playerView);
            PlayerExperience = new PlayerExperienceLevelController(_levelProgressionSO);
            _uiService.UIStart();
        }

        private void InjectDependecies()
        {
            PlayerExperience.InjectDependecies(EventService);
            _uiService.InjectDependecies(EventService);
            PlayerController.InjectDependencies(EventService);
        }
    }
}