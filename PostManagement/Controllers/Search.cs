namespace PostManagement.Controllers
{
    public class Search
    {
        public string StringSearch { get; set; }
        public int page { get; set; }

        private static Search ins { get; set; }

        public static Search Instance()
        {
            if (ins == null)
                ins = new Search();
            return ins;
        }
    }
}
