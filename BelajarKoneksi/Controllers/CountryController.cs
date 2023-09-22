using BelajarKoneksi.Models;
using BelajarKoneksi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Controllers;
public class CountryController
{
    private Country _country;
    private CountryView _countryView;

    public CountryController(Country country, CountryView countryView)
    {
        _country = country;
        _countryView = countryView;
    }

    public void GetAll()
    {
        var results = _country.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _countryView.List(results, "countries");
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
                input = _countryView.GetByIdInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Country id cannot be empty");
                    continue;
                }

                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var result = _country.GetById(input);
        _countryView.Single(result, "countries");
    }

    public void Insert()
    {
        var input = new Country();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _countryView.InsertInput();
                if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Insert(input);
        _countryView.Transaction(result);
    }

    public void Update()
    {
        var input = new Country();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _countryView.UpdateInput();
                if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Update(input);
        _countryView.Transaction(result);
    }

    public void Delete()
    {
        var input = "";
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                input = _countryView.DeleteInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Country id cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        var result = _country.Delete(input);
        _countryView.Transaction(result);
    }
}