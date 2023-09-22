using BelajarKoneksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Views;
public class DepartmentView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("=== Get By Id Department ===");
        Console.Write("Insert department Id : ");
        var id = Console.ReadLine();

        return id;
    }

    public Department InsertInput()
    {
        Console.WriteLine("=== Insert Department ===");
        Console.WriteLine("Insert department id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert department name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert location id");
        var locationId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert manager id");
        var managerId = Convert.ToInt32(Console.ReadLine());

        return new Department
        {
            Id = id,
            Name = name,
            LocationId = locationId,
            ManagerId = managerId
        };
    }

    public Department UpdateInput()
    {
        Console.WriteLine("=== Update Department ===");
        Console.WriteLine("Insert department id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert department name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert location id");
        var locationId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert manager id");
        var managerId = Convert.ToInt32(Console.ReadLine());

        return new Department
        {
            Id = id,
            Name = name,
            LocationId = locationId,
            ManagerId = managerId
        };
    }

    public string DeleteInput()
    {
        Console.WriteLine("=== Delete Department ===");
        Console.Write("Insert department Id : ");
        var id = Console.ReadLine();

        return id;
    }
}
