using Information_Card.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Information_Card.Core.Entities;
using System;

namespace Information_Catd.Infrastructure.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(Context context)
        {
            try
            {
                context.Database.EnsureCreated();
                await SeedEmployeesAsync(context);
            }
            catch 
            {

            }
        }


        private static async Task SeedEmployeesAsync(Context context)
        {
            if (context.Employees.Any())
                return;
            var employees = new List<Employee>()
            {
                new Employee() { Name = "Джо", Surname ="Смит",PhoneNumber = "+375294433901", Salary = 1600, Status = "Работает", 
                    PathPhoto = "https://cdn.trinixy.ru/pics4/20110818/split_family_faces_03.jpg", Job = "Директор" },
                new Employee() { Name = "Карл", Surname ="Оливер", PhoneNumber = "+375293215870", Salary = 1200, Status = "Работает", 
                    PathPhoto = "https://www.zastavki.com/pictures/originals/2014/Men___Male_Celebrity_Beloved_Tom_Cruise_057248_.jpg", Job = "Продавец" },
                new Employee() { Name = "Франц", Surname ="Тасте", PhoneNumber = "+375290975312", Salary = 600, Status = "Уволен",
                    PathPhoto = "https://catherineasquithgallery.com/uploads/posts/2021-02/1614413313_15-p-foto-parnei-na-temnom-fone-15.jpg", Job = "Охранник" },
            };

            context.Employees.AddRange(employees);
            await context.SaveChangesAsync();
        }
    }
}
