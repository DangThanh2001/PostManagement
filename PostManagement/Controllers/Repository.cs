using PostManagement.DataAccess;
using PostManagement.Models;

namespace PostManagement.Controllers
{
    public class Repository
    {
        private static Repository instance;

        public static Repository getInstance()
        {
            if (instance == null)
            {
                instance = new Repository();
            }
            return instance;
        }

        public List<Post> listAllPost()
        {
            return new List<Post>();
        }
    }
}
