namespace SiteFrotas.Models
{
    public class Abastecimento
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public string Data { get; set; } = "";
        public double Litros { get; set; }
        public double ValorTotal { get; set; }
        public int Quilometragem { get; set; }
    }
}