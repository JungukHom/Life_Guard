namespace BusinessConversation
{
    public class CSVVoiceDataHeader
    {
        public static readonly string Location = "Location";   // 장소 (호텔, 공항)
        public static readonly string Lesson = "Lesson";       // 레슨
        public static readonly string Type = "Type";           // 회화, 단어
        public static readonly string Index = "Index";         // 인덱스
        public static readonly string Chinese = "Chinese";     // 한자 원문
        public static readonly string Pinyin = "Pinyin";       // 한자 병음
        public static readonly string Korean = "Korean";       // 한국어 번역
        public static readonly string FileName = "FileName";   // 파일명 (자동 생성)
        public static readonly string Extension = "Extension"; // 확장자
        public static readonly string Remark = "Remark";       // 비고

        //public CSVDataHeader(string lesson, string type, string index, string chinese,
        //                        string pinyin, string korean, string filename, string extension, string remark)
        //{
        //    Lesson = lesson;
        //    Type = type;
        //    Index = index;
        //    Chinese = chinese;
        //    Pinyin = pinyin;
        //    Korean = korean;
        //    FileName = filename;
        //    Extension = extension;
        //    Remark = remark;
        //}
    }
}