using System.ComponentModel.DataAnnotations;

namespace tester_final.Models.Entities
{
    public class UploadDocument
    {
        [Key]
        public Guid Id { get; set; }
        public string LecturerName { get; set; }
        public DateTime ClaimMonth { get; set; }
        public string DocumentName { get; set; }
        public string ContentType { get; set; }
        public byte[] DocumentData { get; set; }
    }
}
