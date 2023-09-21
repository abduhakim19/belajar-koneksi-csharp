using System.Data;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace BelajarKoneksi;

public class Program
{
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. List all countries");
            Console.WriteLine("3. List all locations");
            Console.WriteLine("4. List all Jobs");
            Console.WriteLine("5. List all Departments");
            Console.WriteLine("6. List all Employees");
            Console.WriteLine("7. List all Histories");
            Console.WriteLine("8. List Employee, Departments, Locations, Countries, and Regions");
            Console.WriteLine("9. Total Employee by Department with Min, Max, Avg Salary");

            Console.WriteLine("10. Exit");
            Console.Write("Pilihan anda: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }
    }

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                var region = new Region();
                var regions = region.GetAll();
                GeneralMenu.List(regions, "regions");
                break;

            case "2":
                var country = new Country();
                var countries = country.GetAll();
                GeneralMenu.List(countries, "countries");
                break;

            case "3":
                var location = new Location();
                var locations = location.GetAll();
                GeneralMenu.List(locations, "locations");
                break;

            case "4":
                var job = new Job();
                var jobs = job.GetAll();
                GeneralMenu.List(jobs, "jobs");
                break;

            case "5":
                var department = new Department();
                var departments = department.GetAll();
                GeneralMenu.List(departments, "departments");
                break;

            case "6":
                var employee = new Employee();
                var employees = employee.GetAll();
                GeneralMenu.List(employees, "employees");
                break;

            case "7":
                var history = new History();
                var histories = history.GetAll();
                GeneralMenu.List(histories, "histories");
                break;

            case "8":
                // Inisialisasi
                var employee8 = new Employee();
                var department8 = new Department();
                var location8 = new Location();
                var country8 = new Country();
                var region8 = new Region();
                // Mengambil Data Semuanaya; GetAll()
                var getEmployee8 = employee8.GetAll();
                var getDepartment8 = department8.GetAll();
                var getLocation8 = location8.GetAll();
                var getCountry8 = country8.GetAll();
                var getRegion8 = region8.GetAll();
                // linq 
                var employeeJoin = (from e in getEmployee8
                                    join d in getDepartment8 on e.DepartmentId equals d.Id // join department
                                    join l in getLocation8 on d.LocationId equals l.Id // join location
                                    join c in getCountry8 on l.CountryId equals c.Id // join country
                                    join r in getRegion8 on c.RegionId equals r.Id // join region
                                    select new EmployeeVM
                                    {
                                        Id = e.Id,
                                        FullName =$"{e.FirstName} {e.LastName}", // menyatukan firstname dan lastname
                                        Email = e.Email,
                                        PhoneNumber = e.PhoneNumber,
                                        Salary = e.Salary,
                                        DepartmentName = d.Name,
                                        StreetAddress = l.StreetAddress,
                                        CountryName = c.Name,
                                        RegionName = r.Name
                                    }).ToList();
                GeneralMenu.List(employeeJoin, "regions and countries");
                break;

            case "9":
                // Inisialisasi
                var employee9 = new Employee();
                var department9 = new Department();
                // Mengambil Data Semuanaya; GetAll()
                var getEmployee9 = employee9.GetAll();
                var getDepartment9 = department9.GetAll();

                // Group by Employee berdasarkan DepartmentId yang akan dimasukkan ke variabel g
                // join department berdasarkan g.Key => e.DepartmentId dari variabel g
                var coba = (from e in getEmployee9
                            group e by e.DepartmentId into g
                            join d in getDepartment9 on g.Key equals d.Id
                            where g.Count() > 3 // mengecek departemetn dengan total employee lebih dari 3
                            select new DepartmentAndSalaryVM
                            {
                                DepartmentName = d.Name, // dari join department
                                TotalEmployee = g.Count(), // total employee berdasarkan DepartmentId
                                MaxSalary = g.Max(m => m.Salary), // max salary berdasarkan DepartmentId
                                MinSalary = g.Min(m => m.Salary), // min salary berdasarkan DepartmentId
                                AvgSalary = g.Average(a => a.Salary), // avg salary berdasarkan DepartmentId
                            }).ToList();
                GeneralMenu.List(coba, "regions and countries");
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }

}