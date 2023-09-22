using BelajarKoneksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Views;
public  class JobView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("=== Get By Id Job ===");
        Console.Write("Insert job Id : ");
        var id = Console.ReadLine();

        return id;
    }

    public Job InsertInput()
    {
        Console.WriteLine("=== Insert Job ===");
        Console.WriteLine("Insert job id");
        var id = (Console.ReadLine());
        Console.WriteLine("Insert job title");
        var title = Console.ReadLine();
        Console.WriteLine("Insert Min Salary");
        var minSalary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Max Salary");
        var maxSalary = Convert.ToInt32(Console.ReadLine());

        return new Job
        {
            Id = id,
            Title = title,
            MinSalary = minSalary,
            MaxSalary = maxSalary
        };
    }

    public Job UpdateInput()
    {
        Console.WriteLine("=== Update Job ===");
        Console.WriteLine("Insert job id");
        var id = Console.ReadLine();
        Console.WriteLine("Insert job title");
        var title = Console.ReadLine();
        Console.WriteLine("Insert Min Salary");
        var minSalary = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert Max Salary");
        var maxSalary = Convert.ToInt32(Console.ReadLine());

        return new Job
        {
            Id = id,
            Title = title,
            MinSalary = minSalary,
            MaxSalary = maxSalary,
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
