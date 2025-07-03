using UnityEngine;

namespace PlayerExperience
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController _playerController;
        
        public void SetController(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Update()
        {
            _playerController.Update();
        }
    }
}