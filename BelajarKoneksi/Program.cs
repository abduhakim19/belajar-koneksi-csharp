using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace BelajarKoneksi;

public class Program
{
    // atribut untuk koneksi
    private static readonly string connectionString = "Data Source=HAKIM-COMPUTER;Database=db_hr_dts;Connect Timeout=30;Integrated Security=True";

    private static void Main()
    {
        // GetAllRegions();
        // GetRegionById(1002);
        // InsertRegion("Jawa Timur");
        // GetAllRegions();
        // UpdateRegion(1004, "Jawa Tengah");
        // GetRegionById(1004);
        // DeleteRegion(1004);
        // GetRegionById(1004);

    }
    // GET All: Regions
    public static void GetAllRegions()
    {
        using var connection = new SqlConnection(connectionString); // membuat koneksi baru
        using var command = new SqlCommand(); // inisialiasi command
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM regions"; // Query

        try
        {
            connection.Open(); // Buka Koneksi

            using var reader = command.ExecuteReader(); // mengeksekusi query dan return data atau melakukan datareader
            if (reader.HasRows) // Cek ada data atau tidak
                while (reader.Read()) // loping data dari tabel regions
                {   // menampilkan data; (0) => kolom ke berapa; pastikan sesuai tipe data pada tabel
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            else
                Console.Write("No rows found"); // Jika Data Kosong

            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // GET BY ID: Region
    public static void GetRegionById(int id) 
    {
        using var connection = new SqlConnection(connectionString); // membuat koneksi baru
        using var command = new SqlCommand(); // inisialiasi command

        command.Connection = connection;
        command.CommandText = "SELECT * FROM regions WHERE id=@id;"; // Query @id=>parameter

        try
        {   // Mengisi parameter ke query yang sudah dibuat diatas
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int; // kolom tipe int
            command.Parameters.Add(pId); // menambahkan

            connection.Open();// Buka Koneksi
            using var reader = command.ExecuteReader();// mengeksekusi query dan return data atau melakukan datareader

            if (reader.HasRows) // Cek ada data atau tidak
                while (reader.Read()) // loping data dari tabel regions
                {   // menampilkan data; (0) => kolom ke berapa; pastikan sesuai tipe data pada tabel
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            else
                Console.Write("No rows found"); // Jika Data Kosong
            reader.Close(); // menutup datareader atau reader
            connection.Close(); // tutup koneksi
        }
        catch (Exception ex)
        {    // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    // INSERT: Region
    public static void InsertRegion(string name)
    {
        using var connection = new SqlConnection(connectionString); // membuat koneksi baru
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO regions VALUES (@name);"; // Query @name=>parameter

        try
        {   // Mengisi parameter @name ke query yang sudah dibuat diatas
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar; // kolom tipe varchar
            command.Parameters.Add(pName); //menambahkan

            connection.Open(); // buka koneksi
            using var transaction = connection.BeginTransaction(); //mulai transaksi
            try
            {
                command.Transaction = transaction;
                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yan di commit() berarti tidak bisa di rollback
                connection.Close(); // tutup koneksi

                switch (result)
                {
                    case >= 1: // bila return dari result >= 1 maka berhasil
                        Console.WriteLine("Insert Success");
                        break;
                    default: // selain dari itu gagal
                        Console.WriteLine("Insert Failed");
                        break;
                }
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    // UPDATE: Region
    public static void UpdateRegion(int id, string name)
    {
        using var connection = new SqlConnection(connectionString); // membuat koneksi baru
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE regions SET name=@name WHERE id=@id;"; // Query @name,@id=>parameter

        try
        {   // Mengisi parameter @name ke query yang sudah dibuat diatas
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);
            // Mengisi parameter @id ke query yang sudah dibuat diatas
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            connection.Open(); //buka koneksi
            using var transaction = connection.BeginTransaction(); //inisialisasi transaksi
            try
            {
                command.Transaction = transaction; //mulai transaksi
                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yang di commit() berarti tidak bisa di rollback
                connection.Close();// tutup koneksi
                switch (result)
                {
                    case >= 1:// bila return dari result >= 1 maka berhasil
                        Console.WriteLine("Update Success");
                        break;
                    default:// selain dari itu gagal
                        Console.WriteLine("Upsate Failed");
                        break;
                }
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }   
    // DELETE: Region
    public static void DeleteRegion(int id) 
    {
        using var connection = new SqlConnection(connectionString); // membuat koneksi baru
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "DELETE FROM regions WHERE id=@id;"; // Query @id=>parameter
        try
        {   // Mengisi parameter @id ke query yang sudah dibuat diatas
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pId);

            connection.Open(); // buka koneksi
            using var transaction = connection.BeginTransaction(); //inisialisasi transaksi
            try
            {
                command.Transaction = transaction; //mulai transaksi

                var result = command.ExecuteNonQuery(); //eksekusi query

                transaction.Commit(); // transaksi yan di commit() berarti tidak bisa di rollback
                connection.Close();  // tutup koneksi

                switch (result)
                {
                    case >= 1: // bila return dari result >= 1 maka berhasil
                        Console.WriteLine("Delete Success");
                        break;
                    default: // selain dari itu gagal
                        Console.WriteLine("Delete Failed");
                        break;
                }
            }
            catch (Exception ex)
            {   // jika terdapat error query tidak jadi dieksekusi atau Kembali ke keadaan Sebelum Transaksi
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {   // Error Handling jika terdapat error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}