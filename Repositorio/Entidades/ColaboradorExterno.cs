/*
* Criado em: 12/11/2021
* Alterado em: 05/06/23
*/

namespace Repositorio.Entidades
{
    public class ColaboradorExterno
    {
        #region Propriedades

        public virtual int Id { get; set; }
        public virtual string NomeEmpresa { get; set; }
        public virtual string NomeColaborador { get; set; }
        public virtual string Cargo { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefone { get; set; }
        public virtual int Status { get; set; }

        #endregion Propriedades

        #region Relacionamentos

        public virtual Entidade Entidade { get; set; }
        public virtual EnderecoColaboradorExterno EnderecoColaboradorExterno { get; set; }

        #endregion

        public virtual void SetEnderecoColaborador(EnderecoColaboradorExterno endereco)
        {
            endereco.ColaboradorExterno = this;
            EnderecoColaboradorExterno = endereco;
        }
    }
}