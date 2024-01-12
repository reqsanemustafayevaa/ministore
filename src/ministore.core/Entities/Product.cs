using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.core.Entities
{
    public class Product:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }


    }
}
