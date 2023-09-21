﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DepartmentAndSalaryVM
{   // attribut
    public string DepartmentName { get; set; }
    public int TotalEmployee { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public double AvgSalary { get;set; }
    // Menampilkan data
    public override string ToString()
    {
        return $"{DepartmentName} - {TotalEmployee} - {MinSalary} - {MaxSalary} - {AvgSalary.ToString("0.00")}";
    }
}

