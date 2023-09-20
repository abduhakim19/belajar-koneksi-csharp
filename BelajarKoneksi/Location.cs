﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BelajarKoneksi;
public class Location
{
    public int Id { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryId { get; set; }


    // GET ALL Location
    public List<Location> GetAll()
    {   // inisialisasi locations untuk list object Location
        var locations = new List<Location>();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM locations"; // Query Select tabel locations

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel locations
                {   // menambahkan locations dari tabel ke list
                    locations.Add(new Location
                    {
                        Id = reader.GetInt32(0),
                        StreetAddress = reader.GetString(1),
                        PostalCode = reader.GetString(2),
                        City = reader.GetString(3),
                        StateProvince = reader.GetString(4),
                        CountryId = reader.GetString(5),
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return locations; // mereturn list locations
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<Location>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Location>(); // mereturn list kosong

    }

    // GET BY ID: Location
    public Location GetById(int id)
    {   // inisialisasi locations
        var location = new Location();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM locations WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel locationss
                {   // memasukkan data ke objek location
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.GetString(1);
                    location.PostalCode = reader.GetString(1);
                    location.City = reader.GetString(1);
                    location.StateProvince = reader.GetString(1);
                    location.CountryId = reader.GetString(1);
                    reader.Close(); // menutup datareader atau reader
                    connection.Close(); // tutup koneksi

                    return location; //mereturn objek location
                }

            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            return null; //mereturn null
        }
        catch (Exception ex)
        {    // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return null; //mereturn null
    }
    // INSERT: Location
    public string Insert
        (int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = 
            "INSERT INTO locations VALUES (@id, @street_address, @postal_code, @city, @state_province, @country_id);"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));
            // Mengisi parameter @street_address ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@street_address", streetAddress));
            // Mengisi parameter @postal_code ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@postal_code", postalCode));
            // Mengisi parameter @city ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@city", city));
            // Mengisi parameter @state_province ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@state_province", stateProvince));
            // Mengisi parameter @country_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@country_id", countryId));

            connection.Open(); // buka koneksi
            using var transaction = connection.BeginTransaction(); //inisialisasi transaksi
            try
            {
                command.Transaction = transaction; // mulai transaksi
                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yan di commit() berarti tidak bisa di rollback
                connection.Close(); // tutup koneksi

                return result.ToString(); // mengubah result ke tipe data string
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                return $"Error Transaction: {ex.Message}"; //return pesan error
            }
        }
        catch (Exception ex)
        {   //return pesan error
            return $"Error: {ex.Message}";
        }
    }
    // UPDATE: Location
    public string Update
        (int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText =
            "UPDATE locations SET street_address=@street_address, postal_code=@postal_code, city=@city, state_province=@state_province, country_id=@country_id  WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));
            // Mengisi parameter @street_address ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@street_address", streetAddress));
            // Mengisi parameter @postal_code ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@postal_code", postalCode));
            // Mengisi parameter @city ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@city", city));
            // Mengisi parameter @state_province ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@state_province", stateProvince));
            // Mengisi parameter @country_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@country_id", countryId));

            connection.Open(); //buka koneksi
            using var transaction = connection.BeginTransaction(); //inisialisasi transaksi
            try
            {
                command.Transaction = transaction; // mulai transaksi
                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yang di commit() berarti tidak bisa di rollback
                connection.Close(); // tutup koneksi

                return result.ToString(); // mengubah result ke tipe data string
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                return $"Error Transaction: {ex.Message}"; //return pesan error
            }
        }
        catch (Exception ex)
        {   //return pesan error
            return $"Error: {ex.Message}";
        }
    }
    // DELETE: Location
    public string Delete(int id)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM locations WHERE id=@id;"; // Query
        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open(); //buka koneksi
            using var transaction = connection.BeginTransaction(); //inisialisasi transaksi
            try
            {
                command.Transaction = transaction; // mulai transaksi
                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yang di commit() berarti tidak bisa di rollback
                connection.Close(); // tutup koneksi

                return result.ToString(); // mengubah result ke tipe data string
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                return $"Error Transaction: {ex.Message}"; //return pesan error
            }
        }
        catch (Exception ex)
        {   //return pesan error
            return $"Error: {ex.Message}";
        }
    }
}
