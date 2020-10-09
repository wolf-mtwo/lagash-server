namespace LagashServer.Controllers.helpers
{
    public class Loan
    {
        public string _id { get; set; }
        public string material_type { get; set; }
        public string material_id { get; set; }
        public string ejemplar_id { get; set; }
        public bool is_home { get; set; }
        public string state { get; set; }
    }
}