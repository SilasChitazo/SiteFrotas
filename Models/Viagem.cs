namespace SiteFrotas.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }
        public string Origem { get; set; } = "";
        public string Destino { get; set; } = "";
        public string DataSaida { get; set; } = "";
        public string DataChegada { get; set; } = "";
        public int KmInicial { get; set; }
        public int KmFinal { get; set; }
    }
}
