using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presento.Models
{
    public class UserDBContext : DbContext
    {
        public DbSet<UserVO> DUsers { get; set; }

        public UserDBContext (DbContextOptions<UserDBContext> options) : base(options)
        {

        }
    }
}
