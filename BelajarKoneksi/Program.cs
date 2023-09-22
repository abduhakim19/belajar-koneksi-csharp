using System.Data;
using System.Diagnostics.SymbolStore;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using BelajarKoneksi.ViewModels;
using BelajarKoneksi.Views;
using BelajarKoneksi.Controllers;
using BelajarKoneksi.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Metrics;

namespace BelajarKoneksi;

public class Program
{
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. CRUD regions");
            Console.WriteLine("2. CRUD countries");
            Console.WriteLine("3. CRUD locations");
            Console.WriteLine("4. CRUD Jobs");
            Console.WriteLine("5. CRUD Departments");
            Console.WriteLine("6. CRUD Employees");
            Console.WriteLine("7. CRUD Histories");
            Console.WriteLine("8. List Employee, Departments, Locations, Countries, and Regions");
            Console.WriteLine("9. Total Employee by Department with Min, Max, Avg Salary");

            Console.WriteLine("0. Exit");
            Console.Write("Pilihan anda: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }
    }
    
    public static bool Menu(string input)
    {

        
        bool isInputInt;
        switch (input)
        {
            case "1":
                RegionMenu();
                break;

            case "2":
                CountryMenu();
                break;

            case "3":
                LocationMenu();
                break;

            case "4":
                JobMenu();
                break;

            case "5":
                DepartmentMenu();
                break;


            case "8":
                ListEmployeeMenu();
                break;

            case "9":
                EmployeeDepartment();
                break;

            case "16":
                //DateTime dt;
                //int employeeHistoryId;
                //Console.WriteLine("Masukkan DateTime");
                //bool isInputDate = DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dt) ? true : false;
                //if (!isInputDate)
                //{
                //    Console.WriteLine("You should enter a date");
                //    break;
                //}   
                //Console.WriteLine("Masukkan Id Employee");
                //isInputInt = int.TryParse(Console.ReadLine(), out employeeHistoryId) ? true : false;
                //if (!isInputDate)
                //{
                //    Console.WriteLine("You should enter a integer number");
                //    break;
                //}
                //if (isInputDate && isInputInt)
                //{
                //    var historyById = history.GetByDateAndEmployeeId(dt, employeeHistoryId);
                //    GeneralView.Single(historyById, "regions");
                //}
                break;

            

            case "0":
                return false;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }

    public static void RegionMenu()
    {
        var region = new Region();
        var regionView = new RegionView();

        var regionController = new RegionController(region, regionView);
        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. Get By Id region");
            Console.WriteLine("3. Insert new region");
            Console.WriteLine("4. Update region");
            Console.WriteLine("5. Delete region");
            Console.WriteLine("0. Back");
            Console.Write("Pilih Menu : ");
            var inputSub = Console.ReadLine();
            switch (inputSub)
            {
                case "1":
                    regionController.GetAll();
                    break;
                case "2":
                    regionController.GetById();
                    break;
                case "3":
                    regionController.Insert();
                    break;
                case "4":
                    regionController.Update();
                    break;
                case "5":
                    regionController.Delete();
                    break;
                case "0":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void CountryMenu()
    {
        var country = new Country();
        var countryView = new CountryView();

        var countryController = new CountryController(country, countryView);
        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. List all country");
            Console.WriteLine("2. Get By Id country");
            Console.WriteLine("3. Insert new country");
            Console.WriteLine("4. Update country");
            Console.WriteLine("5. Delete country");
            Console.WriteLine("0. Back");
            Console.Write("Pilih Menu : ");
            var inputSub = Console.ReadLine();
            switch (inputSub)
            {
                case "1":
                    countryController.GetAll();
                    break;
                case "2":
                    countryController.GetById();
                    break;
                case "3":
                    countryController.Insert();
                    break;
                case "4":
                    countryController.Update();
                    break;
                case "5":
                    countryController.Delete();
                    break;
                case "0":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void LocationMenu()
    {
        var location = new Location();
        var locationView = new LocationView();

        var locationController = new LocationController(location, locationView);
        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. List all location");
            Console.WriteLine("2. Get By Id location");
            Console.WriteLine("3. Insert new location");
            Console.WriteLine("4. Update location");
            Console.WriteLine("5. Delete location");
            Console.WriteLine("0. Back");
            Console.Write("Pilih Menu : ");
            var inputSub = Console.ReadLine();
            switch (inputSub)
            {
                case "1":
                    locationController.GetAll();
                    break;
                case "2":
                    locationController.GetById();
                    break;
                case "3":
                    locationController.Insert();
                    break;
                case "4":
                    locationController.Update();
                    break;
                case "5":
                    locationController.Delete();
                    break;
                case "0":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void DepartmentMenu()
    {
        var department = new Department();
        var departmentView = new DepartmentView();

        var departmentController = new DepartmentController(department, departmentView);
        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. List all department");
            Console.WriteLine("2. Get By Id department");
            Console.WriteLine("3. Insert new department");
            Console.WriteLine("4. Update department");
            Console.WriteLine("5. Delete department");
            Console.WriteLine("0. Back");
            Console.Write("Pilih Menu : ");
            var inputSub = Console.ReadLine();
            switch (inputSub)
            {
                case "1":
                    departmentController.GetAll();
                    break;
                case "2":
                    departmentController.GetById();
                    break;
                case "3":
                    departmentController.Insert();
                    break;
                case "4":
                    departmentController.Update();
                    break;
                case "5":
                    departmentController.Delete();
                    break;
                case "0":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void JobMenu()
    {
        var job = new Job();
        var jobView = new JobView();

        var jobController = new JobController(job, jobView);
        var isLoop = true;
        while (isLoop)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("1. List all job");
            Console.WriteLine("2. Get By Id job");
            Console.WriteLine("3. Insert new job");
            Console.WriteLine("4. Update job");
            Console.WriteLine("5. Delete job");
            Console.WriteLine("0. Back");
            Console.Write("Pilih Menu : ");
            var inputSub = Console.ReadLine();
            switch (inputSub)
            {
                case "1":
                    jobController.GetAll();
                    break;
                case "2":
                    jobController.GetById();
                    break;
                case "3":
                    jobController.Insert();
                    break;
                case "4":
                    jobController.Update();
                    break;
                case "5":
                    jobController.Delete();
                    break;
                case "0":
                    isLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void ListEmployeeMenu()
    {
        // Inisialisasi
        var employee = new Employee();
        var department = new Department();
        var location = new Location();
        var country = new Country();
        var region = new Region();
        var countryView = new CountryView();

       

        var listEmployeeController = new ListEmployeeController(country,location,department,
        region,employee, countryView);

        listEmployeeController.GetAll();

    }

    public static void EmployeeDepartment()
    {
        // Inisialisasi
        var employee = new Employee();
        var department = new Department();
        var countryView = new CountryView();
        // Mengambil Data Semuanaya; GetAll()
        var employeeDepartmentController = new EmployeeDepartmentContoller(department, employee, countryView);

        employeeDepartmentController.GetAll();


    }
}