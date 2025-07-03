namespace PlayerExperience.Events
{
    public class EventService 
    {
        public EventController<int> OnGainXp;
        public EventController<int> ResetExperienceValue;
        public EventController<int> ResetLevel;
        public EventController ResetExperience;

        public EventService()
        {
            OnGainXp = new EventController<int>();
            ResetExperience = new EventController();
            ResetLevel = new EventController<int>();
            ResetExperienceValue = new EventController<int>();
        }
    }
}