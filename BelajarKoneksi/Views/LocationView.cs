using BelajarKoneksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Views;
public  class LocationView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("=== Get By Id Location ===");
        Console.Write("Insert location Id : ");
        var id = Console.ReadLine();

        return id;
    }

    public Location InsertInput()
    {
        Console.WriteLine("=== Insert Location ===");
        Console.WriteLine("Insert location id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Street Address");
        var streetAddress = Console.ReadLine();
        Console.WriteLine("Insert Postal Code");
        var postalCode = Console.ReadLine();
        Console.WriteLine("Insert City");
        var city = Console.ReadLine();
        Console.WriteLine("Insert State Province");
        var stateProvince = Console.ReadLine();
        Console.WriteLine("Insert Country Id");
        var countryId = Console.ReadLine();

        return new Location
        {
            Id = id,
            StreetAddress = streetAddress,
            PostalCode = postalCode,
            City = city,
            StateProvince = stateProvince,
            CountryId = countryId,
        };
    }

    public Location UpdateInput()
    {
        Console.WriteLine("=== Update Location ===");
        Console.WriteLine("Insert location id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Street Address");
        var streetAddress = Console.ReadLine();
        Console.WriteLine("Insert Postal Code");
        var postalCode = Console.ReadLine();
        Console.WriteLine("Insert City");
        var city = Console.ReadLine();
        Console.WriteLine("Insert State Province");
        var stateProvince = Console.ReadLine();
        Console.WriteLine("Insert Country Id");
        var countryId = Console.ReadLine();

        return new Location
        {
            Id = id,
            StreetAddress = streetAddress,
            PostalCode = postalCode,
            City = city,
            StateProvince = stateProvince,
            CountryId = countryId,
        };
    }

    public string DeleteInput()
    {
        Console.WriteLine("=== Delete Location ===");
        Console.Write("Insert location Id : ");
        var id = Console.ReadLine();

        return id;
    }
}
