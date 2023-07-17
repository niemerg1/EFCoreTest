using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int FilerId { get; set; }
        public int AttorneyId { get; set; }
        public int CountyId { get; set; }
        public int StatusId { get; set; }

        public required Filer Filer { get; set; }
        public required QueueStatus Status { get; set; }
        public required County County { get; set; }
        public required ICollection<ClaimDefendentLink> ClaimDefendents { get; set; }
        public required ICollection<ClaimPlaintiffLink> ClaimPlaintiffs { get; set; }
    }
}