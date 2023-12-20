namespace WebApplication3.Models
{
    public class Masalar
    {
        private int MasaId { get; set; }
        private string? MasaAdi { get; set; }

        public void MasaEkle(int masaId, string masaAdi)
        {
            Masalar masalar = new Masalar()
            {
                MasaId = masaId,
                MasaAdi = masaAdi,
            };
        }

        public void MasaGuncelle(int masaId, string masaAdi)
        {
            Masalar masalar = new Masalar()
            {
                MasaId = masaId,
                MasaAdi = masaAdi,
            };
        }

        public void MasaSil(int masaId)
        {
            Masalar masalar = new Masalar()
            {
                MasaId = masaId
            };
        }


        public List<Masalar> MasalarGetir()
        {
            List<Masalar> masalar = new List<Masalar>();

            // vt den çek

            return masalar;
        }

    }
}
