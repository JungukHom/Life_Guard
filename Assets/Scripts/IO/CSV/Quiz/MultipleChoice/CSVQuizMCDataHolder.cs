namespace BusinessConversation.CHN.Hotel
{
    public class CSVQuizMCDataHolder
    {
        public readonly string location = "";     // 장소
        public readonly string lesson = "";       // 레슨
        public readonly string index = "";        // OX, 객관식

        public readonly string question = "";     // 문제
        public readonly string explain = "";      // 지문

        public readonly string choice_01 = "";    // 답안 01
        public readonly string choice_02 = "";    // 답안 02
        public readonly string choice_03 = "";    // 답안 03
        public readonly string choice_04 = "";    // 답안 04

        public readonly string answer = "";       // 정답
        public readonly string commentary = "";   // 해설

        public CSVQuizMCDataHolder(string location, string lesson, string index,
                                    string question, string explain,
                                    string choice_01, string choice_02, string choice_03, string choice_04,
                                    string answer, string commentary)
        {
            this.location = location;
            this.lesson = lesson;
            this.index = index;
            this.question = question;
            this.explain = explain;
            this.choice_01 = choice_01;
            this.choice_02 = choice_02;
            this.choice_03 = choice_03;
            this.choice_04 = choice_04;
            this.answer = answer;
            this.commentary = commentary;
        }

        public string GetChoiceStringWithIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return choice_01;
                case 1:
                    return choice_02;
                case 2:
                    return choice_03;
                case 3:
                    return choice_04;
                default:
                    return string.Empty;
            }
        }
    }
}
