using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class ClaimDefendentLink
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int DefendentId { get; set; }

        public required Claim Claim { get; set; }

        public required Defendent Defendent { get; set; }
    }
}