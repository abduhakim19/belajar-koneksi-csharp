using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public int ManagerId { get; set; }

    public override string ToString()
    {
        return $"{Id} - {Name} - {LocationId} - {ManagerId}";
    }

    // GET ALL Department
    public List<Department> GetAll()
    {   // inisialisasi departments untuk list object Department
        var departments = new List<Department>();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM departments"; // Query Select tabel regions

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel departments
                {   // menambahkan department dari tabel ke list
                    departments.Add(new Department
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        LocationId = reader.GetInt32(0),
                        ManagerId = reader.GetInt32(0),
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return departments; // mereturn list departments
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<Department>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Department>(); // mereturn list kosong

    }

    // GET BY ID: Department
    public Department GetById(int id)
    {   // inisialisasi department
        var department = new Department();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM departments WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                reader.Read();
                department.Id = reader.GetInt32(0);
                department.Name = reader.GetString(1);
                department.LocationId = reader.GetInt32(2);
                department.ManagerId = reader.GetInt32(3);

            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            return department; //mereturn null
        }
        catch (Exception ex)
        {    // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Department(); //mereturn null
    }
    // INSERT: Department
    public string Insert(Department department)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText =
            "INSERT INTO departments VALUES (@id, @name, @location_id, @manager_id);"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", department.Id));
            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@name", department.Name));
            // Mengisi parameter @location_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@location_id", department.LocationId));
            // Mengisi parameter @manager_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@manager_id", department.ManagerId));

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
    // UPDATE: Department
    public string Update(Department department)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText =
            "UPDATE departments SET name=@name,location_id=@location_id, manager_id=@manager_id WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", department.Id));
            // Mengisi parameter @name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@name", department.Name));
            // Mengisi parameter @location_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@location_id", department.LocationId));
            // Mengisi parameter @manager_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@manager_id", department.ManagerId));

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
    // DELETE: Department
    public string Delete(int id)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM departments WHERE id=@id;"; // Query
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
