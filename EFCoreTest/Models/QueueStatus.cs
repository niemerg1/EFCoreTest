using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class QueueStatus
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(5)")]
        public required String Code { get; set; }
        [Column(TypeName = "varchar(100)")]
        public required String Description { get; set; }
    }
}