using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("clientes")]
    public class Cliente
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("numero")]
        public int Numero { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("id_cidade")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }
    }
}
