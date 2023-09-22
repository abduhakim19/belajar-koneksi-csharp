using BelajarKoneksi.Models;
using BelajarKoneksi.ViewModels;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class EmployeeDepartmentContoller
{
    private Department _department;
    private Employee _employee;
    private CountryView _countryView;
    public EmployeeDepartmentContoller( Department department, Employee employee, CountryView countryView)
    {

        _department = department;
        _employee = employee;
        _countryView = countryView;
    }
    public void GetAll()
    {
        var getEmployee9 = _employee.GetAll();
        var getDepartment9 = _department.GetAll();
        // Group by Employee berdasarkan DepartmentId yang akan dimasukkan ke variabel g
        // join department berdasarkan g.Key => e.DepartmentId dari variabel g
        var employeeByDepartment = (from e in getEmployee9
                                    group e by e.DepartmentId into g
                                    join d in getDepartment9 on g.Key equals d.Id
                                    where g.Count() > 3 // mengecek departemetn dengan total employee lebih dari 3
                                    select new EmployeeAndDepartmentVM
                                    {
                                        DepartmentName = d.Name, // dari join department
                                        TotalEmployee = g.Count(), // total employee berdasarkan DepartmentId
                                        MaxSalary = g.Max(m => m.Salary), // max salary berdasarkan DepartmentId
                                        MinSalary = g.Min(m => m.Salary), // min salary berdasarkan DepartmentId
                                        AvgSalary = g.Average(a => a.Salary), // avg salary berdasarkan DepartmentId
                                    }).ToList();
        _countryView.List(employeeByDepartment, "Total Employee by Department with Min, Max, Avg Salary");
    }
}
