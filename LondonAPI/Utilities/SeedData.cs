using LondonAPI.Models;

namespace LondonAPI.Utilities
{
    public static class SeedData
    {


        public static async Task InitializeDataAsync(IServiceProvider service)
        {
            await AddTestData(service.GetRequiredService<HotelApiDbContext>());

        }
        public static async Task AddTestData(HotelApiDbContext context)
        {
            if (context == null)
                return;

            if (context.Rooms.Any())
            {
                //already has data
                return;
            }
            else
            {
                context.Rooms.Add(
                    new RoomEntity
                    {
                        Id = new Guid(),
                        Name = "Oxford Suit",
                        Rate = 10119,
                    });

                context.Rooms.Add(
                    new RoomEntity
                    {
                        Id = new Guid(),
                        Name = "Driscroll Suit",
                        Rate = 23959,
                    });

                await context.SaveChangesAsync();
            }
        }

    }
}
