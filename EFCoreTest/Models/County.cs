using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class County
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public required String Name { get; set; }
    }
}