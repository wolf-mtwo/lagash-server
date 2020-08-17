using Wolf.Lagash.Entities.helper;

namespace Wolf.Lagash.Entities.newspaper
{
    public class Newspaper : Material
    {
        public int pages { get; set; }
        public int price { get; set; }
        public int edition { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }
}
