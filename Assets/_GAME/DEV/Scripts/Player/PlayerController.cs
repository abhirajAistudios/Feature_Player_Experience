using PlayerExperience.Events;
using UnityEngine;

namespace PlayerExperience
{
    public class PlayerController
    {
        private PlayerView _playerView;
        private EventService  _eventService;

        public PlayerController(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.SetController(this);
        }

        public void InjectDependencies(EventService eventService)
        {
            _eventService = eventService;
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _eventService.OnGainXp.InvokeEvent(50);
            }
        }
    }
}