using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Xml.Linq;
using BelajarKoneksi.ViewModels;

namespace BelajarKoneksi.Models;
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public decimal ComissionPct { get; set; }
    public int ManagerId { get; set; }
    public string JobId { get; set; }
    public int DepartmentId { get; set; }

    public override string ToString()
    {
        return $"{Id} - {FirstName} - {LastName} - {Email} - {PhoneNumber} - {HireDate} - {Salary} - {ComissionPct} - {ManagerId} - {JobId} - {DepartmentId}";
    }

    // GET ALL Employee
    public List<Employee> GetAll()
    {   // inisialisasi employees untuk list object Employee
        var employees = new List<Employee>();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM employees"; // Query Select tabel regions

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel employees
                {   // menambahkan employee dari tabel ke list
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        HireDate = reader.GetDateTime(5),
                        Salary = reader.GetInt32(6),
                        ComissionPct = reader.GetDecimal(7),
                        ManagerId = reader.GetInt32(8),
                        JobId = reader.GetString(9),
                        DepartmentId = reader.GetInt32(10),
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return employees; // mereturn list employees
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<Employee>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Employee>(); // mereturn list kosong

    }

    // GET BY ID: Employee
    public Employee GetById(int id)
    {   // inisialisasi employee
        var employee = new Employee();
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM employees WHERE id=@id;"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", id));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read())
                    // memasukkan data ke objek employee
                    employee.Id = reader.GetInt32(0);
                employee.FirstName = reader.GetString(1);
                employee.LastName = reader.GetString(2);
                employee.Email = reader.GetString(3);
                employee.PhoneNumber = reader.GetString(4);
                employee.HireDate = reader.GetDateTime(5);
                employee.Salary = reader.GetInt32(6);
                employee.ComissionPct = reader.GetDecimal(7);
                employee.ManagerId = reader.GetInt32(8);
                employee.JobId = reader.GetString(9);
                employee.DepartmentId = reader.GetInt32(10);
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            return employee; //mereturn objek employee
        }
        catch (Exception ex)
        {    // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Employee(); //mereturn null
    }
    // INSERT: Employee
    public string Insert(Employee employee)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText =
            "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, @phone_number" +
            "@hire_date, @salary, @commision_pct, @manager_id, @job_id, @department_id);"; // Query

        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", employee.Id));
            // Mengisi parameter @first_name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@first_name", employee.FirstName));
            // Mengisi parameter @last_name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@last_name", employee.LastName));
            // Mengisi parameter @email ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@email", employee.Email));
            // Mengisi parameter @phone_number ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@phone_number", employee.PhoneNumber));
            // Mengisi parameter @hire_date ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@hire_date", employee.HireDate));
            // Mengisi parameter @salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@salary", employee.Salary));
            // Mengisi parameter @commision_pct ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@commision_pct", employee.ComissionPct));
            // Mengisi parameter @manager_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@manager_id", employee.ManagerId));
            // Mengisi parameter @job_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@job_id", employee.JobId));
            // Mengisi parameter @department_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@department_id", employee.DepartmentId));

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
    // UPDATE: Employee
    public string Update(Employee employee)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "UPDATE employees SET " +
            "first_name=@@first_name, first_name=@last_name, email=@email, phone_number=@phone_number" +
            "hire_date=@hire_date, salary=@salary, commision_pct=@commision_pct, manager_id=@manager_id" +
            "job_id=@job_id, department_id=@department_id WHERE id=@id;"; // Query

        try
        {
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@id", employee.Id));
            // Mengisi parameter @first_name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@first_name", employee.FirstName));
            // Mengisi parameter @last_name ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@last_name", employee.LastName));
            // Mengisi parameter @email ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@email", employee.Email));
            // Mengisi parameter @phone_number ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@phone_number", employee.PhoneNumber));
            // Mengisi parameter @hire_date ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@hire_date", employee.HireDate));
            // Mengisi parameter @salary ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@salary", employee.Salary));
            // Mengisi parameter @commision_pct ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@commision_pct", employee.ComissionPct));
            // Mengisi parameter @manager_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@manager_id", employee.ManagerId));
            // Mengisi parameter @job_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@job_id", employee.JobId));
            // Mengisi parameter @department_id ke query yang sudah dibuat diatas
            command.Parameters.Add(Provider.SetParameter("@department_id", employee.DepartmentId));

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
    // DELETE: Employee
    public string Delete(int id)
    {
        // inisialisasi koneksi
        var connection = Provider.GetConnection();
        // inisialiasi command  
        using var command = Provider.GetCommand();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM employees WHERE id=@id;"; // Query
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
