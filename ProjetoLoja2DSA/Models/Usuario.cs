namespace ProjetoLoja2DSA.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string ?Nome  { get; set; } // ACESSORES REALIZANDO O ENCAPSULAMENTO DOS DADOS
        public string ?Email { get; set; }
        public string ?Senha { get; set; }

    }
}
