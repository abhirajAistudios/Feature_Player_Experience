using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience.UI
{
    public class PlayerExperienceUIView : MonoBehaviour
    {
       private PlayerExperienceUIController _playerExperienceUIController;

       // UI Elements
       public Slider _experienceFiller;
       public TextMeshProUGUI _levelText;
       public TextMeshProUGUI _xpText ;
       
       [SerializeField] private GameObject _levelUpPopUp;
       [SerializeField] private GameObject _xpPopUp;
       [SerializeField] private RectTransform _spawnTargetCanvas;
       public void SetController(PlayerExperienceUIController playerExperienceUIController)
       {
           _playerExperienceUIController = playerExperienceUIController;
       }
       
       // Spawns and animates an XP gain popup
       public void ShowXpPopUp(int value)
       {
           GameObject obj = Instantiate(_xpPopUp, _spawnTargetCanvas);
           TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
           CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        
           text.text = " + " + value;
        
           // Set initial position at center
           obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        
           // Animate the popup: move right over 1.5 seconds
           LeanTween.moveX(obj.GetComponent<RectTransform>(), 200f, 1.5f).setEaseOutCubic();
        
           // Fade out and destroy after animation
           LeanTween.alphaCanvas(canvasGroup, 0f, 1.5f).setEaseOutQuad().setOnComplete(() => {
               Destroy(obj);
           });
       }

       // Spawns and animates a Level Up popup
       public void ShowLevelUpPopUp()
       {
           GameObject obj = Instantiate(_levelUpPopUp, _spawnTargetCanvas);
           TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
           CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
           
           // Set initial position at center
           obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        
           // Animate the popup: move upward over 2 seconds
           LeanTween.moveY(obj.GetComponent<RectTransform>(), 200f, 2.0f).setEaseOutCubic();
        
           // Fade out and destroy after animation
           LeanTween.alphaCanvas(canvasGroup, 0f, 1.5f).setEaseOutQuad().setOnComplete(() => {
               Destroy(obj);
           });
       }
    }
}