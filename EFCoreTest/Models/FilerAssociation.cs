using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class FilerAssociation
    {
        public int Id { get; set; }
        public int FilerId { get; set; }
        public int ClaimId { get; set; }
        public int AssociationId { get; set; }

        public required Filer Filer { get ; set; }
        public required Claim Claim { get; set; }
        public required Filer Association { get; set; }
    }
}