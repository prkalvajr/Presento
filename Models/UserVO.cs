using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presento.Models
{
    public class UserVO
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; }    // "nickname": "pedro.kalva",

        [Column(TypeName = "nvarchar(35)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Picture { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastLogin { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        public EnumAuthType AuthType { get; set; }

        public enum EnumAuthType : int
        {
            UsernameAndPassword = 1,
            GoggleAccount = 2
        }
    }
}
