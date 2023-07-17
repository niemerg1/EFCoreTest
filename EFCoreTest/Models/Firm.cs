using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class Firm
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public String Name { get; set; }

        public required ICollection<Filer> Filers { get; set; }
    }
}