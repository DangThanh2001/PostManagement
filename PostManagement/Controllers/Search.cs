namespace PostManagement.Controllers
{
    public class Search
    {
        public string StringSearch { get; set; }

        private static Search ins { get; set; }

        public static Search Instance()
        {
            if (ins == null)
                ins = new Search();
            return ins;
        }
    }
}
