using BelajarKoneksi.Models;
using BelajarKoneksi.ViewModels;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class ListEmployeeController
{
    private Country _country;
    private Location _location;
    private Department _department;
    private Region _region;
    private Employee _employee;
    private CountryView _countryView;
    public ListEmployeeController(Country country, Location location, Department department,
        Region region, Employee employee, CountryView countryView)
    {
        _country = country;
        _location = location;
        _department = department;
        _region = region;
        _employee = employee;
        _countryView = countryView;
    }
    public void GetAll()
    {
        var region8 = new Region();
        // Mengambil Data Semuanaya; GetAll()
        var getEmployee8 = _employee.GetAll();
        var getDepartment8 = _department.GetAll();
        var getLocation8 = _location.GetAll();
        var getCountry8 = _country.GetAll();
        var getRegion8 = _region.GetAll();
        // linq 
        var employeeJoin = (from e in getEmployee8 // e alias dari Employee
                            join d in getDepartment8 on e.DepartmentId equals d.Id // join department
                            join l in getLocation8 on d.LocationId equals l.Id // join location
                            join c in getCountry8 on l.CountryId equals c.Id // join country
                            join r in getRegion8 on c.RegionId equals r.Id // join region
                            select new EmployeeVM
                            {
                                Id = e.Id,
                                FullName = $"{e.FirstName} {e.LastName}", // menyatukan firstname dan lastname
                                Email = e.Email,
                                PhoneNumber = e.PhoneNumber,
                                Salary = e.Salary,
                                DepartmentName = d.Name,
                                StreetAddress = l.StreetAddress,
                                CountryName = c.Name,
                                RegionName = r.Name
                            }).ToList();
        _countryView.List(employeeJoin, "List Employee, Departments, Locations, Countries, and Regions");
    }
}
