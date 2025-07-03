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
       public TextMeshProUGUI _xpGainedPopUp;
       public TextMeshProUGUI _levelUpPopUp ;
       public void SetController(PlayerExperienceUIController playerExperienceUIController)
       {
           _playerExperienceUIController = playerExperienceUIController;
       }
    }
}