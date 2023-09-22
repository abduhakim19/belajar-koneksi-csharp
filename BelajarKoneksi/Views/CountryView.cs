using BelajarKoneksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Views;
public class CountryView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("=== Get By Id Country ===");
        Console.Write("Insert country Id : ");
        var id = Console.ReadLine();

        return id;
    }

    public Country InsertInput()
    {
        Console.WriteLine("=== Insert Country ===");
        Console.WriteLine("Insert country id");
        var id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert region id");
        var regionId = Convert.ToInt32(Console.ReadLine());

        return new Country
        {
            Id = id,
            Name = name,
            RegionId = regionId
        };
    }

    public Country UpdateInput()
    {
        Console.WriteLine("=== Update Country ===");
        Console.WriteLine("Insert country id");
        var id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert region id");
        var regionId = Convert.ToInt32(Console.ReadLine());

        return new Country
        {
            Id = id,
            Name = name,
            RegionId = regionId
        };
    }

    public string DeleteInput()
    {
        Console.WriteLine("=== Delete Country ===");
        Console.Write("Insert country Id : ");
        var id = Console.ReadLine();

        return id;
    }
}
