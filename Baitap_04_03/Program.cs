using System;
using System.Linq;
using System.Collections.Generic;

namespace BaitapLTC
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
    }

    public class Car : Vehicle
    {
        public string Color { get; set; }
    }

    public class Truck : Vehicle
    {
        public string Company { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Cars = new List<Car>
            {
                new Car {Id = "1", Brand = "Toyota", Price = 475600, Place = "Nhat Ban", Year = 2019, Color = "Do"},
                new Car {Id = "2", Brand = "Audi", Price = 300500, Place = "Duc", Year = 2012, Color = "Trang"},
                new Car {Id = "3", Brand = "Ford", Price = 520000, Place = "My", Year = 2015, Color = "Do"},
                new Car {Id = "4", Brand = "Mercedes Benz", Price = 1538000, Place = "Duc", Year = 2021, Color = "Den"},
                new Car {Id = "5", Brand = "Mitsubishi", Price = 650000, Place = "My", Year = 2024, Color = "Do"},
                new Car {Id = "6", Brand = "Huyndai", Price = 215000, Place = "Han Quoc", Year = 2004, Color = "Den"},
                new Car {Id = "7", Brand = "Ford", Price = 235000, Place = "My", Year = 2010, Color = "Xam"},
                new Car {Id = "8", Brand = "Audi", Price = 655000, Place = "Duc", Year = 2013, Color = "Xanh"},
                new Car {Id = "9", Brand = "Mitsubishi", Price = 1125000, Place = "My", Year = 2016,Color = "Xam"},
                new Car {Id = "10", Brand = "Huyndai", Price = 240000, Place = "Han Quoc", Year = 2015, Color = "Nau"}
            };

            List<Truck> Trucks = new List<Truck> 
            { 
                new Truck {Id = "1", Brand = "Huyndai", Price = 350000, Place = "Han Quoc", Year = 2015, Company ="Huyndai Thanh Cong VN"},
                new Truck {Id = "2", Brand = "Kamaz", Price = 750000, Place = "Lien Bang Nga", Year = 2016, Company ="Kamaz Viet Nam"},
                new Truck {Id = "3", Brand = "Tera", Price = 600000, Place = "Han Quoc", Year = 2023, Company ="Daehan Motors"},
                new Truck {Id = "4", Brand = "Suzuki", Price = 240000, Place = "Nhat Ban", Year = 2018, Company ="Suzuki Viet Nam"},
                new Truck {Id = "5", Brand = "Hino", Price = 530000, Place = "Nhat Ban", Year = 2021, Company ="Hino Motors"}


            };

            //tạo danh sách lựa chọn
            Console.WriteLine("Vui long lua chon:");
            Console.WriteLine("\n1.Hien thi cac Car co gia trong khoang 100.000 đen 250.000;");
            Console.WriteLine("2.Hien thi cac Car co nam san xuat > 1990;");
            Console.WriteLine("3.Gom cac Car theo hang san xuat, tinh tong gia tri theo nhom;");
            Console.WriteLine("4.Hien thi danh sach Truck theo thu tu nam san xuat moi nhat;");
            Console.WriteLine("5.Hien thi ten cong ty chu quan cua Truck;");
            Console.WriteLine("6.Dung lai.\n");
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        var priceCars = from car in Cars
                                        where car.Price >= 100000 && car.Price <= 250000
                                        select car;
                        Console.WriteLine("\n1.Hien thi cac Car co gia trong khoang 100.000 đen 250.000:\n");
                        foreach (var car in priceCars)
                        {
                            Console.WriteLine($"STT: {car.Id}, Hang: {car.Brand}, Gia: { car.Price}, Place: {car.Place}, Nam: {car.Year}, Mau: {car.Color}");
                        }
                        break;

                    case 2:
                        var yearCars = from car in Cars
                                       where car.Year > 1990
                                       select car;
                        Console.WriteLine("\n2.Hien thi cac Car co nam san xuat > 1990:\n");
                        foreach (var car in yearCars)
                        {
                            Console.WriteLine($"STT: {car.Id}, Hang: {car.Brand}, Gia: { car.Price}, Place: {car.Place}, Nam: {car.Year}, Mau: {car.Color}");
                        }
                        break;

                    case 3:
                        var groupbyBrand = from car in Cars
                                           group car by car.Brand into brandGroup
                                           select new
                                           {
                                               Brand = brandGroup.Key,
                                               toTalPrice = brandGroup.Sum(car => car.Price)
                                           };
                        Console.WriteLine("\n3.Gom cac Car theo hang san xuat, tinh tong gia tri theo nhom:\n");
                        foreach (var group in groupbyBrand)
                        {
                            Console.WriteLine($"Hang: {group.Brand}, Tong gia tri: {group.toTalPrice}");
                        }
                        break;

                    case 4:
                        var sortedTruck = Trucks.OrderByDescending(truck => truck.Year);
                        Console.WriteLine("\n4.Hien thi danh sach Truck theo thu tu nam san xuat moi nhat:\n");
                        foreach (var truck in sortedTruck)
                        {
                            Console.WriteLine($"STT: {truck.Id}, Hang: {truck.Brand}, Gia: { truck.Price}, Place: {truck.Place}, Nam: {truck.Year}, Cong ty: {truck.Company}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n5.Hien thi ten cong ty chu quan cua Truck:\n");
                        foreach (var truck in Trucks)
                        {
                            Console.WriteLine($"Cong ty: {truck.Company}");
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Lua chon sai. Chon lai!");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
