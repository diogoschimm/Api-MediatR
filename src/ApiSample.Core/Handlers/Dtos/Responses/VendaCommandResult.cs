namespace ApiSample.Core.Handlers.Dtos.Responses
{
    public class VendaCommandResult
    {
        public VendaCommandResult(int idVenda)
        {
            this.IdVenda = idVenda;
        }

        public int IdVenda { get; set; }
    }
}
