using System;

namespace Model
{
    public class Projeto
    {
        public int Id;
        public string Nome;
        public DateTime DataCriacao;
        public DateTime DataFinalizacao;

        public int IdCliente;
        public Cliente Cliente;
    }
}
