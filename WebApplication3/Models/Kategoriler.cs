using Microsoft.Data.SqlClient;

namespace WebApplication3.Models
{
    public class Kategoriler
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }

        List<Kategoriler> kategorilerListesi = new List<Kategoriler>();

        public void KategoriEkle(string KategoriAdi)
        {
            string query = "INSERT INTO Kategoriler( KategoriAdi ) VALUES ('" + KategoriAdi + "');";
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
                            Console.WriteLine("Kategori Eklendi");
                        }
                        else
                        {
                            Console.WriteLine("Kategori Eklenemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }

        public void KategoriSil(int KategoriId)
        {

            string query = "DELETE FROM Kategoriler WHERE KategoriId = " + KategoriId + "; DELETE FROM Urunler WHERE KategoriID = " + KategoriId + ";";
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
                            Console.WriteLine("Kategori Silindi");
                        }
                        else
                        {
                            Console.WriteLine("Kategori Silinemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }

        public void KategoriGuncelle(int KategoriId, string KategoriAdi)
        {

            string query = "UPDATE Kategoriler SET KategoriAdi = '" + KategoriAdi + "' WHERE KategoriId = " + KategoriId + ";";

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
                            Console.WriteLine("Kategori Güncellendi");
                        }
                        else
                        {
                            Console.WriteLine("Kategori Güncellenemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }

        }

        public List<Kategoriler> KategorilerGetir()
        {


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


                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Kategoriler", connection);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Kategoriler kategori = new Kategoriler()
                        {
                            KategoriId = Convert.ToInt32(reader["KategoriId"]),
                            KategoriAdi = reader["KategoriAdi"].ToString()

                        };
                        kategorilerListesi.Add(kategori);

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
            return kategorilerListesi;

        }

    }
}
