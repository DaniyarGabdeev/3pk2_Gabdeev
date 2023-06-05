namespace Tekst
{
    public class Info
    {
        public string NameTxt { get; set; }
        public string NoteTxt { get; set; }

        public Info(string name, string txt)
        {
            NameTxt = name;
            NoteTxt = txt;
        }
    }
}