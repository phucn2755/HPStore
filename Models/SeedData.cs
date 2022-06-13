using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace HPStore.Models
{

        public static class SeedData
        {
            public static void EnsurePopulated(IApplicationBuilder app)
            {
                HPStoreDbContext context =
               app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < HPStoreDbContext > ();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tainghes.Any())
                {
                    context.Tainghes.AddRange(
                    new Tainghe
                    {
                        TenTainghe = "SONY WH-1000XM4",
                        Mota = "Công nghệ chống ồn hàng đầu, Âm thanh tuyệt đỉnh, Công nghệ nghe thông minh, Tự do không dây, âm thanh đỉnh cao",
                        Hang = "SONY",
                        Loai = "HEADPHONE",
                        Gia = 8.490000m
                    },
                    new Tainghe
                    {
                        TenTainghe = "AirPods Pro",
                        Mota = "Thiết kế nhỏ gọn, dễ dàng đem theo bất cứ đâu,Tích hợp công nghệ chống ồn chủ động,hỗ trợ sạc không dây",
                        Hang = "Apple",
                        Loai = "TrueWireless",
                        Gia = 4.890000m
                    },
                    new Tainghe
                    {
                        TenTainghe = "JBL T115BTWHT",
                        Mota = "Thời lượng pin cao lên đến 8h sử dụng cùng với sạc nhanh, Chất âm đặc trưng, Chuẩn kết nối: Bluetooth 4.2",
                        Hang = "JBL",
                        Loai = "Có dây Bluetooth",
                        Gia = 949.000m
                    },
                    new Tainghe
                    {
                        TenTainghe = "Samsung Galaxy Buds Live",
                        Mota = "Kiểu dáng hạt đậu độc đáo",
                        Hang = "SamSung",
                        Loai = "TrueWireless",
                        Gia = 1.390000m
                    },
                    new Tainghe
                    {
                        TenTainghe = " BOSE QUIETCOMFORT EARBUDS",
                        Mota = "Âm thanh hoàn hảo với khả năng chống ồn," +
                                "Công nghệ Bose Acoustic Noise Cancelling™," +
                                "Cảm giác đeo thoải mái, Điều khiển cảm ứng dễ dàng,Kháng nước IPX4 ,Trang bị Bluetooth 5.1 mới nhất",
                        Hang = "Bose",
                        Loai = "EARBUDS",
                        Gia = 7.490000m
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }

