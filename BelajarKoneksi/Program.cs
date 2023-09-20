using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace BelajarKoneksi;

public class Program
{
    private static void Main()
    {
        //region
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


        //country
        var country = new Country();

        //var getAllCountry = country.GetAll();
        //if (getAllCountry.Count > 0)
        //{
        //    foreach (var country1 in getAllCountry)
        //    {
        //        Console.WriteLine($"Id: {country1.Id}, Name: {country1.Name}, RegionId: {country1.RegionId}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        // Locations
        var location = new Location();

        //var getAllLocation = location.GetAll();
        //if (getAllLocation.Count > 0)
        //{
        //    foreach (var location1 in getAllLocation)
        //    {
        //        Console.WriteLine($"Id: {location1.Id}, Name: {location1.StreetAddress}, RegionId: {location1.PostalCode}, City: {location1.City}, StateProvince: {location1.StateProvince}, CountryId: {location1.CountryId}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        // Departments
        var department = new Department();

        //var getAllDepartment = department.GetAll();
        //if (getAllDepartment.Count > 0)
        //{
        //    foreach (var department1 in getAllDepartment)
        //    {
        //        Console.WriteLine($"Id: {department1.Id}, Name: {department1.Name}, LocationId: {department1.LocationId}, ManagerId: {department1.ManagerId}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        // Employees
        var employee = new Employee();

        //var getAllEmployee = employee.GetAll();
        //if (getAllEmployee.Count > 0)
        //{
        //    foreach (var employee1 in getAllEmployee)
        //    {
        //        Console.WriteLine($"Id: {employee1.Id}, FirstName: " +
        //            $"{employee1.FirstName}, LastName: {employee1.LastName}, " +
        //            $"HireDate: {employee1.HireDate}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        // Histories
        var history = new History();

        //var getAllHistory = history.GetAll();
        //if (getAllHistory.Count > 0)
        //{
        //    foreach (var history1 in getAllHistory)
        //    {
        //        Console.WriteLine($"Id: {history1.StartDate}, EmployeeId: " +
        //            $"{history1.EmployeeId}, EndDate: {history1.EndDate}, " +
        //            $"JobId: {history1.JobId}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}

        // Jobs
        //var job = new Job();

        //var getAllJob = job.GetAll();
        //if (getAllJob.Count > 0)
        //{
        //    foreach (var job1 in getAllJob)
        //    {
        //        Console.WriteLine($"Id: {job1.Id}, Title: " +
        //            $"{job1.Title}, MinSalary: {job1.MinSalary}, " +
        //            $"MaxSalary: {job1.MaxSalary}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No data found");
        //}


    }

}