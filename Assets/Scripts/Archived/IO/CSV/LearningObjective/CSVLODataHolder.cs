namespace BusinessConversation
{
    public class CSVLODataHolder
    {
        public readonly string location = "";   // 장소 (호텔, 공항)
        public readonly string lesson = "";       // 레슨
        public readonly string lo = "";// 학습목표

        public CSVLODataHolder(string location, string lesson, string lo)
        {
            this.location = location;
            this.lesson = lesson;
            this.lo = lo;
        }
    }
}