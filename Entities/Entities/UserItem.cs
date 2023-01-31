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
    public class UserItem
    {

        public UserItem()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public Guid IdWeb { get; private set; }
        public string UserName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; private set; }
        public int IdRol { get; set; }
        public string Password { get; set; }
        public string EncryptedPassword { get; set; }


    }


}