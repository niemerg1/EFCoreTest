using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class Plaintiff
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public Boolean IsPatient { get; set; }
        public Boolean IsMinor { get; set; }
    }
}