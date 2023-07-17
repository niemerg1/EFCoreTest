using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class Filer
    {
        public int Id { get; set; }
        public int FilerTypeId { get; set; }

        public required FilerType FilerType { get; set; }
        public required ICollection<Claim> Claims { get; set; }
        public required ICollection<FilerAssociation> FilerAssociationsAsFiler { get; set; }
        public required ICollection<FilerAssociation> FilerAssociationsAsAssociation { get; set; }
    }
}