using CuaHangXe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CuaHangXe.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {


            using (var context = new CuaHangXeContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<CuaHangXeContext>>()))
            {
                // Look for any 
                if (context.Xe.Any())
                {
                    return; // DB has been seeded
                }
                context.Xe.AddRange(
                new Xe
                {
                    Title = "HonDa",
                    ReleaseDate = DateTime.Parse("2023-2-12"),
                    Genre = "Wave",
                    Price = 7.99M
                },
                new Xe
                {
                    Title = "Yamaha",
                    ReleaseDate = DateTime.Parse("2023-3-13"),
                    Genre = "Yama",
                    Price = 8.99M
                },
                new Xe
                {
                    Title = "Suzuki",
                    ReleaseDate = DateTime.Parse("2010-2-23"),
                    Genre = "Hayate",
                    Price = 9.99M
                },
                new Xe
                {
                    Title = "Cup",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "SPCup",
                    Price = 3.99M
                }
                );
                context.SaveChanges();
            }
        }
    }
}
