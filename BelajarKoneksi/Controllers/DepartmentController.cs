using BelajarKoneksi.Models;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class DepartmentController
{
    private Department _department;
    private DepartmentView _departmentView;

    public DepartmentController(Department department, DepartmentView departmentView)
    {
        _department = department;
        _departmentView = departmentView;
    }

    public void GetAll()
    {
        var results = _department.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _departmentView.List(results, "departments");
        }
    }

    public void GetById()
    {
        var departmentId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _departmentView.GetByIdInput();
                var isInputInt = int.TryParse(input, out departmentId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Department id cannot be empty");
                    continue;
                }
                if (!isInputInt)
                {
                    Console.WriteLine("You should enter a integer number");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var departmentById = _department.GetById(departmentId);
        _departmentView.Single(departmentById, "department");
    }

    public void Insert()
    {
        var input = new Department();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _departmentView.InsertInput();
                if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Department name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _department.Insert(input);
        _departmentView.Transaction(result);
    }

    public void Update()
    {
        var input = new Department();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _departmentView.UpdateInput();
                if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Department name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _department.Update(input);
        _departmentView.Transaction(result);
    }

    public void Delete()
    {
        var departmentId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _departmentView.DeleteInput();
                var isInputInt = int.TryParse(input, out departmentId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Department id cannot be empty");
                    continue;
                }
                if (!isInputInt)
                {
                    Console.WriteLine("You should enter a integer number");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var result = _department.Delete(departmentId);
        _departmentView.Transaction(result);
    }
}
