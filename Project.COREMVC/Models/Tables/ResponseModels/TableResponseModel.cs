using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Tables.ResponseModels
{
    public class TableResponseModel
    {
        public int ID { get; set; }
        public int TableNo { get; set; }
        public string Situation { get; set; }
        public DataStatus Status { get; set; }
    }
}
