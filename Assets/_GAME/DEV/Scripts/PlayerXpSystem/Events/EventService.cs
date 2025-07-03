namespace PlayerExperience.Events
{
    public class EventService 
    {
        public EventController<int> OnGainXp;
        public EventController<int> ResetMaxExperienceValue;
        public EventController<int> ResetLevel;
        public EventController<int> ResetExperience;

        public EventService()
        {
            OnGainXp = new EventController<int>();
            ResetExperience = new EventController<int>();
            ResetLevel = new EventController<int>();
            ResetMaxExperienceValue = new EventController<int>();
        }
    }
}