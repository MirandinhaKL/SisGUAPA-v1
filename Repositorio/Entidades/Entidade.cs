using System;
using System.Collections.Generic;

namespace Repositorio.Entidades
{
    public class Entidade
    {
        public Entidade()
        {
            this.Usuarios = new List<Usuario>();
        }

        #region Propriedades

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual int TipoEntidade { get; set; }
        public virtual int Estado { get; set; }
        public virtual string Telefone { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        #endregion

        #region Referencias

        public virtual EnderecoEntidade EnderecoEntidade { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; }

        #endregion

        public virtual void AddUsuario(Usuario usuario)
        {
            usuario.Entidade = this;
            Usuarios.Add(usuario);
        }

        public virtual void RemoveUsuario(Usuario usuario)
        {
            usuario.Entidade = this;
            Usuarios.Remove(usuario);
        }

        public virtual void SetEnderecoEntidade(EnderecoEntidade endereco)
        {
            endereco.Entidade = this;
            EnderecoEntidade = endereco;
        }
    }
}
