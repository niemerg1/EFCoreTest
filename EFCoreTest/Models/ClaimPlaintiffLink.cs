using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class ClaimPlaintiffLink
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int PlaintiffId { get; set; }

        public required Claim Claim { get; set; }

        public required Plaintiff Plaintiff { get; set; }
    }
}