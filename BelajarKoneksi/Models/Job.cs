using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BelajarKoneksi.Models;
public class Job
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Title} - {MinSalary} - {MaxSalary}";
    }

    // GET ALL Job
    public List<Job> GetAll()
    {   // inisialisasi jobs untuk list object Job
        var jobs = new List<Job>();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM jobs"; // Query Select tabel jobs

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel jobs
                {   // menambahkan jobs dari tabel ke list
                    jobs.Add(new Job
                    {
                        Id = reader.GetString(0),
                        Title = reader.GetString(1),
                        MinSalary = reader.GetInt32(2),
                        MaxSalary = reader.GetInt32(3)
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return jobs; // mereturn list jobs
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<Job>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Job>(); // mereturn list kosong

    }

    // GET BY ID: Job
    public Job GetById(string id)
    {   // inisialisasi job
        var job = new Job();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM jobs WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                reader.Read();
                // memasukkan data ke objek job
                job.Id = reader.GetString(0);
                job.Title = reader.GetString(1);
                job.MinSalary = reader.GetInt32(2);
                job.MaxSalary = reader.GetInt32(3);
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            return job; //mereturn objek job
        }
        catch (Exception ex)
        {    // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Job(); //mereturn null
    }
    // INSERT: Job
    public string Insert(Job job)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "INSERT INTO jobs VALUES (@id, @title, @min_salary, @max_salary);"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", job.Id));
            // Mengisi parameter @title ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@title", job.Title));
            // Mengisi parameter @min_salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@min_salary", job.MinSalary));
            // Mengisi parameter @max_salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@max_salary", job.MaxSalary));

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
    // UPDATE: Job
    public string Update(Job job)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "UPDATE jobs SET title=@title, min_salary=@min_salary, max_salary=@max_salary  WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", job.Id));
            // Mengisi parameter @title ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@title", job.Title));
            // Mengisi parameter @min_salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@min_salary", job.MinSalary));
            // Mengisi parameter @max_salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@max_salary", job.MaxSalary));

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
    // DELETE: Job
    public string Delete
        (string id)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM jobs WHERE id=@id;"; // Query
        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", id));

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

