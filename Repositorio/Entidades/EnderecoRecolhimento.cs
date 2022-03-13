/*
 * Alterada em: 24/09/21
 */
namespace Repositorio.Entidades
{
    public class EnderecoRecolhimento
    {
        public virtual int Id { get; set; }
        public virtual int Estado { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string CEP { get; set; }

        // Relacionamentos

        public virtual Entidade Entidade { get; set; }

    }
}
