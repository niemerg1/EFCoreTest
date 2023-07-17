using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Models
{
    public class FilerType
    {
        public int Id { get; set; }
        public required String Type { get; set; }
    }
}