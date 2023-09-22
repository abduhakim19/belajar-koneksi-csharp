using BelajarKoneksi.Models;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class JobController
{
    private Job _job;
    private JobView _jobView;

    public JobController(Job job, JobView jobView)
    {
        _job = job;
        _jobView = jobView;
    }

    public void GetAll()
    {
        var results = _job.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _jobView.List(results, "countries");
        }
    }

    public void GetById()
    {
        var input = "";
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _jobView.GetByIdInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Job id cannot be empty");
                    continue;
                }

                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var result = _job.GetById(input);
        _jobView.Single(result, "countries");
    }

    public void Insert()
    {
        var input = new Job();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _jobView.InsertInput();
                if (string.IsNullOrEmpty(input.Title))
                {
                    Console.WriteLine("Job name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _job.Insert(input);
        _jobView.Transaction(result);
    }

    public void Update()
    {
        var input = new Job();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _jobView.UpdateInput();
                if (string.IsNullOrEmpty(input.Title))
                {
                    Console.WriteLine("Job title cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _job.Update(input);
        _jobView.Transaction(result);
    }

    public void Delete()
    {
        var input = "";
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _jobView.DeleteInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Job id cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var result = _job.Delete(input);
        _jobView.Transaction(result);
    }
}
