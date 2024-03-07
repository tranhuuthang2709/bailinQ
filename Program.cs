using System;
using System.Collections.Generic;
using System.Linq;

// Định nghĩa lớp cha Vehicle
class Vehicle
{
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}

// Lớp Car kế thừa từ lớp Vehicle
class Car : Vehicle
{
    public Car(string manufacturer, int year, double price)
    {
        Manufacturer = manufacturer;
        Year = year;
        Price = price;
    }
}

// Lớp Truck kế thừa từ lớp Vehicle
class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string manufacturer, int year, double price, string company)
    {
        Manufacturer = manufacturer;
        Year = year;
        Price = price;
        Company = company;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo danh sách các Car
        List<Car> cars = new List<Car>
        {
            new Car("Toyota", 2005, 150000),
            new Car("Honda", 1998, 80000),
            new Car("Ford", 2000, 120000),
            new Car("Toyota", 1995, 70000),
            new Car("Honda", 2001, 180000)
        };

        // Hiển thị các xe có giá trong khoảng 100.000 đến 250.000 và năm sản xuất > 1990
        Console.WriteLine("1)a, cac xe co gia trong khoang 100.000 den 250.000:");
        var Filterbyprice = cars.Where(car => car.Price >= 100000 && car.Price <= 250000 );
        foreach (var car in Filterbyprice)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer}, gia: {car.Price}");
        }
        Console.WriteLine("b, Cac xe co nam san xuat > 1990:");
        var Filterbyyear = cars.Where(car => car.Year > 1990);
        foreach (var car in Filterbyyear)
        {
            Console.WriteLine($"Manufacturer: {car.Manufacturer}, nam: {car.Year}");
        }
        // Gom các xe theo hãng sản xuất, tính tổng giá trị theo
        Console.WriteLine("c,cac xe theo hang san xuat, tong gia tri theo nhom:");
        var groupedCars = cars.GroupBy(car => car.Manufacturer)
                              .Select(group => new { Manufacturer = group.Key, TotalPrice = group.Sum(car => car.Price) });
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"Manufacturer: {group.Manufacturer}, tong gia: {group.TotalPrice}");
        }

        // Tạo danh sách các Truck
        List<Truck> trucks = new List<Truck>
        {
            new Truck("Volvo", 2015, 200000, "Volvo Group"),
            new Truck("Ford", 2010, 180000, "Ford Motor Company"),
            new Truck("Toyota", 2020, 250000, "Toyota Industries")
        };

        // Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
        Console.WriteLine("2)a, danh sach Truck theo thu tu nam san xuat moi nhat");
        var orderedTrucks = trucks.OrderByDescending(truck => truck.Year);
        foreach (var truck in orderedTrucks)
        {
            Console.WriteLine($"Manufacturer: {truck.Manufacturer}, nam: {truck.Year}, gia: {truck.Price}");
        }

        // Hiển thị tên cty chủ quản của Truck
        Console.WriteLine(" b,danh sach ten cong ty chu quan cua Truck");
        foreach (var truck in trucks)
        {
            Console.WriteLine($"Manufacturer: {truck.Manufacturer}, cong ty: {truck.Company}");
        }
        Console.ReadLine();
    }
    
}
