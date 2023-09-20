﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace BelajarKoneksi;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // GET ALL Region
    public List<Region> GetAll()
    {   // inisialisasi regions untuk list object Region
        var regions = new List<Region>();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM regions"; // Query Select tabel regions

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows) 
            {
                while (reader.Read()) // loping data dari tabel regions
                {   // menambahkan region dari tabel ke list
                    regions.Add(new Region
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return regions; // mereturn list regions
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<Region>(); 
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Region>(); // mereturn list kosong

    }

    // GET BY ID: Region
    public Region GetById(int id)
    {   // inisialisasi region
        var region = new Region();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM regions WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel regions
                {   // memasukkan data ke objek region
                    region.Id = reader.GetInt32(0); 
                    region.Name = reader.GetString(1);
                    reader.Close(); // menutup datareader atau reader
                    connection.Close(); // tutup koneksi

                    return region; //mereturn objek region
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
    // INSERT: Region
    public string Insert(string name)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "INSERT INTO regions VALUES (@name);"; // Query

        try
        {   // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@name", name));

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
    // UPDATE: Region
    public string Update(int id, string name)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "UPDATE regions SET name=@name WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));

            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@name", name));

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
    // DELETE: Region
    public string Delete(int id)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM regions WHERE id=@id;"; // Query
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
