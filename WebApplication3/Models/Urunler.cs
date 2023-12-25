using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;

namespace WebApplication3.Models
{
    public class Urunler
    {
        public int UrunId { get; set; }
        public string? UrunAdi { get; set; }
        public string? UrunAciklamasi { get; set; }
        public string? KategoriAdi { get; set; }
        public int? KategoriId { get; set; }
        public decimal? UrunFiyat { get; set; }
        public string? UrunFotografi { get; set; }


        List<Urunler> urunListesi = new List<Urunler>();

        public string FotografCek(string kaynak)
        {
            string hedef = @"\img\";
            string dosyayolu = hedef;
            char[] kaynakArray = kaynak.ToCharArray();
            Array.Reverse(kaynakArray);
            char karakter = '\\';
            //File.Copy(kaynak,hedef);

            //  "\\wwwroot\\img\\burger.jpg"
            int index = Array.IndexOf(kaynakArray, karakter);
            if (index != -1)
            {
                Console.WriteLine("Var");
                for (int i = index - 1; i >= 0; i--)
                {
                    dosyayolu += kaynakArray[i];
                }

                Console.WriteLine(dosyayolu);
            }
            else
            {
                Console.WriteLine("yok");
            }
            return dosyayolu;

        }

        public void UrunOlustur(string UrunAdi, string UrunAciklamasi, int KategoriId, decimal UrunFiyat, string UrunFotografi)
        {

            Console.WriteLine(UrunAdi + " " + UrunAciklamasi + " " + KategoriId + " " + UrunFiyat + " " + UrunFotografi + "\n\n");
            
            string? foto = FotografCek(UrunFotografi);

            //string query = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, KategoriID, UrunFiyati, UrunFotografi) VALUES (@UrunAdi, UrunAciklamasi, KategoriId, UrunFiyati, UrunFotografi)";


            string query = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, KategoriID, UrunFiyati, UrunFotografi) VALUES ('" + UrunAdi + "', '" + UrunAciklamasi + "', " + KategoriId + ", " + UrunFiyat + ", " + " '" + foto.ToString() + "');";
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
                            Console.WriteLine("Ürün Eklendi");
                        }
                        else
                        {
                            Console.WriteLine("Ürün eklenemdi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }
        public void UrunSil(int UrunId)
        {
            string query = "DELETE FROM Urunler WHERE UrunId = " + UrunId + ";";
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
                            Console.WriteLine("Ürün Silindi");
                        }
                        else
                        {
                            Console.WriteLine("Ürün Silinemedi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }
        }

        public void UrunGuncelle(int UrunId, string UrunAdi, string UrunAciklamasi, int KategoriId, decimal UrunFiyat, string UrunFotografi)
        {
            

            string? foto = FotografCek(UrunFotografi);



            //string query = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, KategoriID, UrunFiyati, UrunFotografi) VALUES ('" + UrunAdi + "', '" + UrunAciklamasi + "', " + KategoriId + ", " + UrunFiyat + ", " + " '" + foto.ToString() + "');";
            string query = "UPDATE Urunler SET UrunAdi = '" + UrunAdi + "',UrunAciklamasi = '" + UrunAciklamasi + "', KategoriID = '" + KategoriId + "', UrunFiyati= " + UrunFiyat + ", UrunFotografi= '" + foto.ToString() + "' WHERE UrunId = " + UrunId + ";";
            
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
                            Console.WriteLine("Ürün Eklendi");
                        }
                        else
                        {
                            Console.WriteLine("Ürün eklenemdi");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hata:" + ex.Message);
                    }

                }

            }

        }


        public List<Urunler> UrunGetir()
        {
            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Veri tabanına bağlantı sağlanıyor
                    connection.Open();
                    Console.WriteLine("Bağlantı başarıyla açıldı.");

                    SqlCommand cmd = new SqlCommand("SELECT dbo.Urunler.*, dbo.Kategoriler.KategoriAdi AS KategoriAdi FROM dbo.Kategoriler INNER JOIN dbo.Urunler ON dbo.Kategoriler.KategoriId = dbo.Urunler.KategoriID;", connection);
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        Urunler urun = new Urunler()
                        {
                            UrunId = Convert.ToInt32(reader["UrunId"]),
                            UrunAdi = reader["UrunAdi"].ToString(),
                            UrunAciklamasi = reader["UrunAciklamasi"].ToString(),
                            KategoriAdi = reader["KategoriAdi"].ToString(),
                            UrunFiyat = Convert.ToDecimal(reader["UrunFiyati"]),
                            UrunFotografi = reader["UrunFotografi"].ToString()
                        };
                        urunListesi.Add(urun);

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

            return urunListesi;

        }

    }
}
