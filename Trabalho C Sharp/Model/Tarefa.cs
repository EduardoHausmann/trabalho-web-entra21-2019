using System;

namespace Model
{
    public class Tarefa
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public DateTime Duracao;

        public int IdUsuario;
        public int IdProjeto;
        public int IdCategoria;
        public Usuario Usuario;
        public Categoria Categoria;
        public Projeto Projeto;
    }
}
