using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }

    // GET ALL Country
    public List<Country> GetAll()
    {   // inisialisasi countries untuk list object Country
        var countries = new List<Country>();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM countries"; // Query Select tabel countrys

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel Countries
                {   // menambahkan country dari tabel ke list
                    countries.Add(new Country
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        RegionId = reader.GetInt32(2)
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return countries; // mereturn list countries
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list kosong
            return new List<Country>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Country>(); // mereturn list  kosong

    }

    // GET BY ID: Country
    public Country GetById(string id)
    {   // inisialisasi country
        var country = new Country();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM countries WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel countries
                {   // memasukkan data ke objek country
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);
                    reader.Close(); // menutup datareader atau reader
                    connection.Close(); // tutup koneksi

                    return country; //mereturn objek country
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
    // INSERT: Country
    public string Insert(string id, string name, int regionId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "INSERT INTO countries VALUES (@id, @name, @region_id);"; // Query @name=>parameter

        try
        {   // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));
            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@name", name));
            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@region_id", regionId));

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
    // UPDATE: Country
    public string Update(string id, string name, int regionId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "UPDATE countries SET name=@name, region_id= WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@id", id));
            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@name", name));
            // Mengisi parameter @region_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@region_id", regionId));

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
    // DELETE: Country
    public string Delete(string id)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM countries WHERE id=@id;"; // Query
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

