namespace ApiSample.Core.DomainObjects
{
    public class ItemVenda
    {
        public ItemVenda(string descricao, int qtd, decimal valorUnitario)
        {
            this.Descricao = descricao;
            this.Qtd = qtd;
            this.ValorUnitario = valorUnitario;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Qtd { get; set; }
        public decimal ValorUnitario { get; set; }

        public decimal ObterTotal()
        {
            return Qtd * ValorUnitario;
        }
    }
}
