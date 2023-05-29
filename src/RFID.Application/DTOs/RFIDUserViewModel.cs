namespace RFID.Application.DTOs
{
    public class RFIDUserViewModel
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; } = string.Empty;
        public string TagId { get; set; } = string.Empty;       // CardId 
        public DateOnly DateOnly { get; set; }
        public int UserId { get; set; }
    }
}
