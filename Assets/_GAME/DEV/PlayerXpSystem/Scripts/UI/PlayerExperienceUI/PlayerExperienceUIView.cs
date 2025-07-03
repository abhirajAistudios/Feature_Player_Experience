using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerExperience.UI
{
    public class PlayerExperienceUIView : MonoBehaviour
    {
       private PlayerExperienceUIController _playerExperienceUIController;

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
       
       public void ShowXpPopUp(int amount, bool isPositive)
       {
           GameObject obj = Instantiate(_xpPopUp, _spawnTargetCanvas);
           TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
           CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        
           text.text = (isPositive ? "+" : "-") + Mathf.Abs(amount);
        
           // Set starting position
           obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        
           // Animate with LeanTween
           LeanTween.moveX(obj.GetComponent<RectTransform>(), 200f, 1.5f).setEaseOutCubic();
        
           LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEaseOutQuad().setOnComplete(() => {
               Destroy(obj);
           });
       }

       public void ShowLevelUpPopUp()
       {
           GameObject obj = Instantiate(_levelUpPopUp, _spawnTargetCanvas);
           TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
           CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
           
           obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        
           // Animate with LeanTween
           LeanTween.moveY(obj.GetComponent<RectTransform>(), 100f, 2.0f).setEaseOutCubic();
        
           LeanTween.alphaCanvas(canvasGroup, 0f, 0.5f).setEaseOutQuad().setOnComplete(() => {
               Destroy(obj);
           });
       }
    }
}