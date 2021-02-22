namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections.Generic;

    public class QuizChoiceData
    {
        private static QuizChoiceData _instance = null;

        private QuizChoiceData() { }

        public static QuizChoiceData GetOrCreate() => _instance ?? (_instance = new QuizChoiceData());

        ////////////////////////////////////////////////// 0 = "O" | 1 = "X"

        // TODO : change this private
        public Dictionary<int, int> answers = new Dictionary<int, int>();

        public void EditChoice(int key, int value)
        {
            if (answers.ContainsKey(key))
            {
                answers.Remove(key);
                answers.Add(key, value);
            }
            else
            {
                answers.Add(key, value);
            }
        }

        public bool HasChoice(int key)
        {
            return answers.ContainsKey(key);
        }

        public int GetChoice(int key)
        {
            return answers[key];
        }
    }
}
