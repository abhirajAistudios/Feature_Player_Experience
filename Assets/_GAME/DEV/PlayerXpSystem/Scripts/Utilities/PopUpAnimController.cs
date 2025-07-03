using UnityEngine;

namespace PlayerExperience
{
    public class PopUpAnimController : MonoBehaviour
    {
        [SerializeField] Transform _targetTransform;
        [SerializeField] private float _duration;
        [SerializeField] LeanTweenType _easeType; 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Move();
            }
        }
        private void Move()
        {
            LeanTween.moveX(gameObject, _targetTransform.position.x, _duration).setEase(_easeType);
        }
    }
}