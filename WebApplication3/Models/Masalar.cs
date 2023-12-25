using Microsoft.Data.SqlClient;

namespace WebApplication3.Models
{
    public class Masalar
    {
        public int MasaId { get; set; }
        public string? MasaAdi { get; set; }

        List<Masalar> masalarListesi = new List<Masalar>();
        public void MasaEkle(string masaAdi)
        {
            string query = "INSERT INTO Masalar( MasaAdi ) VALUES ('" + masaAdi + "');";
            Console.WriteLine(query);
            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        int affectedRow = command.ExecuteNonQuery();

                        if (affectedRow > 0)
                        {
                            Console.WriteLine("Masa Eklendi");
                        }
                        else
                        {
                            Console.WriteLine("Masa Eklenemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }

        public void MasaGuncelle(int masaId, string masaAdi)
        {
            string query = "UPDATE Masalar SET MasaAdi = '" + masaAdi + "' WHERE MasaId = " + masaId + ";";

            Console.WriteLine(query);
            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        int affectedRow = command.ExecuteNonQuery();

                        if (affectedRow > 0)
                        {
                            Console.WriteLine("Masa Güncellendi");
                        }
                        else
                        {
                            Console.WriteLine("Masa Güncellenemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }

        public void MasaSil(int masaId)
        {
            string query = "DELETE FROM Masalar WHERE MasaId = " + masaId + ";";
            Console.WriteLine(query);
            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        int affectedRow = command.ExecuteNonQuery();

                        if (affectedRow > 0)
                        {
                            Console.WriteLine("Masa Silindi");
                        }
                        else
                        {
                            Console.WriteLine("Masa Silinemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }


        public List<Masalar> MasalarGetir()
        {
            List<Masalar> masaListesi = new List<Masalar>();

            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Veri tabanına bağlantı sağlanıyor
                    connection.Open();
                    if (connection.State != 0)
                    {
                        Console.WriteLine("Bağlantı başarıyla açıldı.");
                    }


                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Masalar", connection);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Masalar masa = new Masalar()
                        {
                            MasaId = Convert.ToInt32(reader["MasaId"]),
                            MasaAdi = reader["MasaAdi"].ToString()
                        };
                        masaListesi.Add(masa);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bağlantı hatası: " + ex.Message);
                }
                connection.Close();
                if (connection.State == 0)
                {
                    Console.WriteLine("Bağlantı kapandı.");
                }

            }

            return masaListesi;
        }

    }
}
