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
            /*
            Urunler urunler = new Urunler()
            {
                UrunAdi = UrunAdi,
                UrunAciklamasi = UrunAciklamasi,
                KategoriId = KategoriId,
                UrunFiyat = UrunFiyat,
                UrunFotografi = UrunFotografi
            };
            */
            string? foto = FotografCek(UrunFotografi);

            //string query = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, KategoriID, UrunFiyati, UrunFotografi) VALUES (@UrunAdi, UrunAciklamasi, KategoriId, UrunFiyati, UrunFotografi)";


            string query = "INSERT INTO Urunler (UrunAdi, UrunAciklamasi, KategoriID, UrunFiyati, UrunFotografi) VALUES ('" + UrunAdi + "', '" + UrunAciklamasi + "', " + KategoriId + ", " + UrunFiyat + ", " + " '" + foto.ToString() + "');";
            Console.WriteLine(query);
            string connectionString = $"Data Source=localhost;Initial Catalog=SR_db;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    /*
                    command.Parameters.AddWithValue("@UrunAdi", UrunAdi);
                    command.Parameters.AddWithValue("@UrunAciklamasi", UrunAciklamasi);
                    command.Parameters.AddWithValue("@KategoriId", KategoriId);
                    command.Parameters.AddWithValue("@UrunFiyati", UrunFiyat);
                    command.Parameters.AddWithValue("@UrunFotografi", UrunFotografi);
                    */

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
            Urunler urunler = new Urunler()
            {
                UrunId = UrunId
            };
        }

        public void UrunGuncelle(int UrunId, string UrunAdi, string UrunAciklamasi, string KategoriAdi, decimal UrunFiyat, string UrunFotografi)
        {
            Urunler urunler = new Urunler()
            {
                UrunId = UrunId,
                UrunAdi = UrunAdi,
                UrunAciklamasi = UrunAciklamasi,
                KategoriAdi = KategoriAdi,
                UrunFiyat = UrunFiyat,
                UrunFotografi = UrunFotografi
            };
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
