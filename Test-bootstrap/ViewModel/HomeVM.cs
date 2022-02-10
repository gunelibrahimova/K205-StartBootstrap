using Testbootstrap.Models;

namespace Testbootstrap.ViewModel
{
    public class HomeVM
    {
        public Masthead Masthead { get; set; }
        public List<About> Abouts { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Contact> Contacts { get; set; }
        
    }
}
