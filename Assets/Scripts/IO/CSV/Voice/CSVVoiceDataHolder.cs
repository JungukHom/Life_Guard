namespace BusinessConversation
{
    public class CSVVoiceDataHolder
    {
        private static readonly string VoiceFileDefaultPath = "Record";

        public readonly string location = "";
        public readonly string lesson = "";
        public readonly string type = "";

        public readonly string chinese = "";
        public readonly string pinyin = "";
        public readonly string korean = "";
        public readonly string fileName = "";

        public CSVVoiceDataHolder(string location, string lesson, string type,
                                string chinese, string pinyin, string korean, string fileName)
        {
            this.location = location;
            this.lesson = lesson;
            this.type = type;

            this.chinese = chinese;
            this.pinyin = pinyin;
            this.korean = korean;

            this.fileName = fileName;
        }

        public string GetVoiceFilePath()
        {
            return $"{VoiceFileDefaultPath}/{fileName}";
            //return $"{VoiceFileDefaultPath}{location}/{fileName}";
        }
    }
}
