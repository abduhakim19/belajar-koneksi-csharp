using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace BelajarKoneksi;

public class Program
{
    private static void Main()
    {
        var region = new Region();

        //var getAllRegion = region.GetAll();
        //if (getAllRegion.Count > 0)
        //{
        //    foreach (var region1 in getAllRegion)
        //    {
        //        Console.WriteLine($"Id: {region1.Id}, Name: {region1.Name}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        //var region1 = region.GetById(21);
        //var region1 = region.GetById(25);
        //if (region1 != null)
        //{
        //    Console.WriteLine($"Id: {region1.Id}, Name: {region1.Name}");
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        //var insertResult = region.Insert("Region 5");
        //int.TryParse(insertResult, out int result);
        //if (result > 0)
        //{
        //    Console.WriteLine("Insert Success");
        //}
        //else
        //{
        //    Console.WriteLine("Insert Failed");
        //    Console.WriteLine(insertResult);
        //}

        //var updateResult = region.Update(22, "Region 5");
        //int.TryParse(updateResult, out int result);
        //if (result > 0)
        //{
        //    Console.WriteLine("Update Success");
        //}
        //else
        //{
        //    Console.WriteLine("Update Failed");
        //    Console.WriteLine(updateResult);
        //}

        //var DeleteResult = region.Delete(1005);
        //int.TryParse(DeleteResult, out int result);
        //if (result > 0)
        //{
        //    Console.WriteLine("Delete Success");
        //}
        //else
        //{
        //    Console.WriteLine("Delete Failed");
        //    Console.WriteLine(DeleteResult);
        //}


    }

}