namespace PlayerExperience.Events
{
    public class EventService 
    {
        public EventController<int> OnIncreaseOfXp;
        public EventController<int> RefreshExperienceValue;
        public EventController RefreshExperience;
        public EventController<int> OnLevelUp;

        public EventService()
        {
            OnIncreaseOfXp = new EventController<int>();
            RefreshExperience = new EventController();
            OnLevelUp = new EventController<int>();
            RefreshExperienceValue = new EventController<int>();
        }
    }
}