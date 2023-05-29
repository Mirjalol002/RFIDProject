namespace RFID.Domain.Entities
{
    public class RFIDModel
    {
        public int Id { get; set; }
        public string ToolName { get; set; } = string.Empty;
        public string TagId { get; set; } = string.Empty;       // CardId 
        public DateOnly DateOnly { get; set; }
        public RFIDUser RFIDUser { get; set; }
    }
}
