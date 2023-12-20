using Microsoft.Data.SqlClient;

namespace WebApplication3.Models
{
    public class Kategoriler
    {
        public int KategoriId { get; set; }
        public string? KategoriAdi { get; set; }

        List<Kategoriler> kategorilerListesi = new List<Kategoriler>();

        public void KategoriEkle(int KategoriId, string KategoriAdi)
        {
            Kategoriler kategoriler = new Kategoriler()
            {
                KategoriId = KategoriId,
                KategoriAdi = KategoriAdi,
            };
        }

        public void KategoriSil(int KategoriId)
        {
            Kategoriler kategoriler = new Kategoriler()
            {
                KategoriId = KategoriId,
            };
        }

        public void KategoriGuncelle(int KategoriId, string KategoriAdi)
        {
            Kategoriler kategoriler = new Kategoriler()
            {
                KategoriId = KategoriId,
                KategoriAdi = KategoriAdi,
            };
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
                    if (connection.State!=0)
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
