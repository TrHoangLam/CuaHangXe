using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuaHangXe.Models;

namespace CuaHangXe.Data
{
    public class CuaHangXeContext : DbContext
    {
        public CuaHangXeContext (DbContextOptions<CuaHangXeContext> options)
            : base(options)
        {
        }

        public DbSet<CuaHangXe.Models.Xe> Xe { get; set; } = default!;
    }
}
