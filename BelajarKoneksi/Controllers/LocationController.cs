using BelajarKoneksi.Models;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class LocationController
{
    private Location _location;
    private LocationView _locationView;

    public LocationController(Location location, LocationView locationView)
    {
        _location = location;
        _locationView = locationView;
    }

    public void GetAll()
    {
        var results = _location.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _locationView.List(results, "locations");
        }
    }

    public void GetById()
    {
        var locationId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _locationView.GetByIdInput();
                var isInputInt = int.TryParse(input, out locationId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Location id cannot be empty");
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
        var departmentById = _location.GetById(locationId);
        _locationView.Single(departmentById, "location");
    }

    public void Insert()
    {
        var input = new Location();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _locationView.InsertInput();
                if (string.IsNullOrEmpty(input.StreetAddress))
                {
                    Console.WriteLine("Street Address cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Insert(input);
        _locationView.Transaction(result);
    }

    public void Update()
    {
        var input = new Location();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _locationView.UpdateInput();
                if (string.IsNullOrEmpty(input.StreetAddress))
                {
                    Console.WriteLine("StreetAddress cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Update(input);
        _locationView.Transaction(result);
    }

    public void Delete()
    {
        var locationId = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                var input = _locationView.DeleteInput();
                var isInputInt = int.TryParse(input, out locationId) ? true : false;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Location id cannot be empty");
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
        var result = _location.Delete(locationId);
        _locationView.Transaction(result);
    }
}

