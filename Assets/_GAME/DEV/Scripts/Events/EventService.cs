using System;
using UnityEngine;

namespace PlayerExperience
{
    public class EventService : MonoBehaviour
    {
        public static EventController<int> OnIncreaseOfXp;
        public static EventController<int> RefreshExperienceValue;
        public static EventController RefreshExperience;

        public void Awake()
        {
            OnIncreaseOfXp = new EventController<int>();
            RefreshExperience = new EventController();
            RefreshExperienceValue = new EventController<int>();
        }
    }
}