using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelajarKoneksi.Models;
using BelajarKoneksi.Views;

namespace BelajarKoneksi.Controllers;
public class RegionController
{
    private Region _region;
    private RegionView _regionView;

    public RegionController(Region region, RegionView regionView)
    {
        _region = region;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var results = _region.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _regionView.List(results, "regions");
        }
    }

    public void GetById() 
    {
        var regionId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _regionView.GetByIdInput();
                var isInputInt = int.TryParse( input, out regionId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Region id cannot be empty");
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
        var regionById = _region.GetById(regionId);
        _regionView.Single(regionById, "regions");
    }

    public void Insert()
    {
        var input = new Region();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _regionView.InsertInput();
                if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Insert(input);
        _regionView.Transaction(result);
    }

    public void Update()
    {
        var region = new Region();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                region = _regionView.UpdateInput();
                if (string.IsNullOrEmpty(region.Name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Update(region);
        _regionView.Transaction(result);
    }

    public void Delete()
    {
        var regionId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _regionView.DeleteInput();
                var isInputInt = int.TryParse(input, out regionId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Region id cannot be empty");
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
        var regionDelete = _region.Delete(regionId);
        _regionView.Transaction(regionDelete);
    }
}
