using System;
using UnityEngine;

namespace PlayerExperience
{
    public class EventService : MonoBehaviour
    {
        public static EventController<int> OnIncreaseOfXp;
        public static EventController<int> RefreshExperienceValue;
        public static EventController RefreshExperience;
        public static EventController<int> OnLevelUp;

        public void Awake()
        {
            OnIncreaseOfXp = new EventController<int>();
            RefreshExperience = new EventController();
            OnLevelUp = new EventController<int>();
            RefreshExperienceValue = new EventController<int>();
        }
    }
}