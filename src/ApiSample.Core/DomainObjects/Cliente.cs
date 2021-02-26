namespace ApiSample.Core.DomainObjects
{
    public class Cliente
    {
        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public void MudarNome(string novoNome)
        {
            this.Nome = novoNome;
        }
    }
}
