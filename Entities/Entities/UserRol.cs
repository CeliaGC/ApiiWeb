using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserRol
    {
        [Key]
        public int IdRol { get; set; }
        public string NameRol { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}