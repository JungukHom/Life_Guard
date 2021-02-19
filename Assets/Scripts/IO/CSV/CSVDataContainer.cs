namespace BusinessConversation
{
    public class CSVDataContainer
    {
        protected string GetStringLocation(ELocation location)
        {
            switch (location)
            {
                case ELocation.Hotel:
                    return "Hotel";
                case ELocation.Airport:
                    return "Airport";
                default:
                    return "";
            }
        }

        protected string GetStringType(EVoiceType type)
        {            
            switch (type)
            {
                case EVoiceType.Conversation:
                    return "회화";
                case EVoiceType.Word:
                    return "단어";
                default:
                    return "";
            }
        }

        protected string GetStringLesson(EHotelLesson lesson)
        {
            return ((int)++lesson).ToString();
        }

        protected string GetStringLesson(EAirportLesson lesson)
        {
            return ((int)++lesson).ToString();
        }
    }
}
