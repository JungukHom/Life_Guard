namespace BusinessConversation.CHN.Hotel
{
    public class CSVQuizOXDataHolder
    {
        private static readonly string VoiceFileDefaultPath = "Datas/Record";

        public readonly string location = "Location";     // 장소 (호텔, 공항)
        public readonly string lesson = "Lesson";         // 레슨
        public readonly string index = "Index";           // 회화, 단어

        public readonly string question = "Question";     // 문제
        public readonly string explain = "Explian";       // 지문

        public readonly string answer = "Answer";         // 정답

        public readonly string korean = "Korean";         // 번역
        public readonly string commentary = "Commentary"; // 해설
        public readonly string fileName = "FileName";     // 음성파일 이름

        public CSVQuizOXDataHolder(string location, string lesson, string index,
                                    string question, string explain, string answer,
                                    string korean, string commentary, string fileName)
        {
            this.location = location;
            this.lesson = lesson;
            this.index = index;
            this.question = question;
            this.explain = explain;
            this.answer = answer;
            this.korean = korean;
            this.commentary = commentary;
            this.fileName = fileName;
        }

        public string GetVoiceFilePath()
        {
            return $"{VoiceFileDefaultPath}/{fileName}";
        }
    }
}