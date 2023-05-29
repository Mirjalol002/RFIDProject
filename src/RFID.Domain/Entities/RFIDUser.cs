using RFID.Domain.Enums;

namespace RFID.Domain.Entities
{
    public class RFIDUser
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public Positions Position { get; set; }
        public string Email { get; set; } = string.Empty;
        public int RFIDModelId { get; set; }
        public RFIDModel Model { get; set; }
    }
}