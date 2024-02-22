namespace ControleEstoque.Models
{
    public class Medicamento
    {
        public string Nome { get; set; } = string.Empty;
        public string PricipioAtivo { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string CodigoBarra { get; set; } = string.Empty;
        public string CodigoInterno { get; set; } = string.Empty;
        public int Quantidade { get;  private set; }

        public bool Receber(Medicamento codigoMedicamento, int quantidade)
        {
            codigoMedicamento.Quantidade += quantidade;
            return true;
        }
    }
}
