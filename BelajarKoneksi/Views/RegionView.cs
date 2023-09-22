using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelajarKoneksi.Models;

namespace BelajarKoneksi.Views;
public class RegionView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("=== Get By Id Region ===");
        Console.Write("Insert region Id : ");
        var id = Console.ReadLine();

        return id;
    }

    public Region InsertInput()
    {
        Console.WriteLine("=== Insert Region ===");
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();

        return new Region{
            Id = 0,
            Name = name
        };
    }

    public Region UpdateInput()
    {
        Console.WriteLine("=== Update Region ===");
        Console.Write("Insert region Id : ");
        var id = Convert.ToInt32(Console.ReadLine());
        

        Console.Write("Insert region name : ");
        var name = Console.ReadLine();

        return new Region {
            Id = id,
            Name = name
        };
    }

    public string DeleteInput()
    {
        Console.WriteLine("=== Delete Region ===");
        Console.Write("Insert region Id : ");
        var id = Console.ReadLine();

        return id;
    }
}
