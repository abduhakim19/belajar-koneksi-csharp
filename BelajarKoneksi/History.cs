using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarKoneksi;
public class History
{
    public DateTime StartDate { get; set; }
    public int EmployeeId { get; set; }
    public DateTime EndDate { get; set; }
    public int DepartmentId  { get; set; }
    public string JobId { get; set; }

    // GET ALL History
    public List<History> GetAll()
    {   // inisialisasi history untuk list object History
        var histories = new List<History>();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM histories"; // Query Select tabel regions

        try
        {
            connection.Open(); // Buka Koneksi
            // mengeksekusi query dan return data atau melakukan datareader
            using var reader = command.ExecuteReader();
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel histories
                {   // menambahkan history dari tabel ke list
                    histories.Add(new History
                    {
                        StartDate = reader.GetDateTime(0),
                        EmployeeId = reader.GetInt32(1),
                        EndDate = reader.GetDateTime(2),
                        DepartmentId = reader.GetInt32(3),
                        JobId = reader.GetString(4)
                    });
                }
                reader.Close(); // menutup datareader atau reader
                connection.Close(); // tutup koneksi

                return histories; // mereturn list regions
            }
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
            // mereturn list  kosong
            return new List<History>();
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<History>(); // mereturn list kosong

    }

    // GET BY ID: History
    public History GetByDateAndEmployeeId(DateTime startDate, int employeeId)
    {   // inisialisasi region
        var history = new History();
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "SELECT * FROM histories WHERE " +
            "start_date=@start_date AND employee_id=@employee_id;"; // Query

        try
        {   // Mengisi parameter @start_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@start_date", startDate));
            // Mengisi parameter @employee_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@employee_id", employeeId));

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader
            // Cek ada data atau tidak
            if (reader.HasRows)
            {
                while (reader.Read()) // loping data dari tabel histories
                {   // memasukkan data ke objek histries
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);
                    reader.Close(); // menutup datareader atau reader
                    connection.Close(); // tutup koneksi

                    return history; //mereturn objek history
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
    // INSERT: History
    public string Insert
        (DateTime startDate, int employeeId, DateTime endDate, int  departmentId, int jobId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "INSERT INTO histories VALUES (" +
            "@start_date, @employee_id, @end_date, @department_id, @job_id);"; // Query

        try
        {   // Mengisi parameter @start_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@start_date", startDate));
            // Mengisi parameter @employee_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@employee_id", employeeId));
            // Mengisi parameter @end_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@end_date", endDate));
            // Mengisi parameter @department_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@department_id", departmentId));
            // Mengisi parameter @job_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@job_id", jobId));

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
    // UPDATE: History
    public string Update
        (DateTime startDate, int employeeId, DateTime endDate, int departmentId, int jobId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "UPDATE histories SET " +
            "end_date=@end_date, department_id=@department_id" +
            "job_id=@job_id WHERE start_date=@start_date AND employee_id=@employee_id;"; // Query

        try
        {
            // Mengisi parameter @start_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@start_date", startDate));
            // Mengisi parameter @employee_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@employee_id", employeeId));
            // Mengisi parameter @end_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@end_date", endDate));
            // Mengisi parameter @department_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@department_id", departmentId));
            // Mengisi parameter @job_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@job_id", jobId));

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
    // DELETE: History
    public string Delete(DateTime startDate, int employeeId)
    {
        // inisialiasi command  
        using var command = new SqlCommand();
        // inisialisasi connection untuk koneksi ke database
        var connection = DatabaseManager.GetConnection();

        command.Connection = connection; // menghubungkan command dan database 
        command.CommandText = "DELETE FROM histories WHERE start_date=@start_date AND employee_id=@employee_id;"; // Query
        try
        {   // Mengisi parameter @start_date ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@start_date", startDate));
            // Mengisi parameter @employee_id ke query yang sudah dibuat diatas
            command.Parameters.Add(new SqlParameter("@employee_id", employeeId));

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
