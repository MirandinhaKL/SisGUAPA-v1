/*
 * Criado em: 19/10/21
 */
using Repositorio.Entidades;

namespace Desktop.Relatorios.Campos
{
    public class ImpAdotante
    {
        public virtual string Nome { get; set; }
        public virtual string CPF { get; set; }
        public virtual string RG { get; set; }
        public virtual string DataNascimento { get; set; }
        public virtual string Genero { get; set; }
        public virtual string EstadoCivil { get; set; }
        public virtual string Profissao { get; set; }
        public virtual string Telefone1 { get; set; }
        public virtual string Telefone2 { get; set; }
        public virtual string Email { get; set; }

        // Endereço
        public virtual string Cidade { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Observacao { get; set; }
        public virtual Adocao Adocao { get; set; }

        public static ImpAdotante GetCabecalho()
        {
            var titlulo = new ImpAdotante()
            {
                Nome = "Nome",
                CPF = "CPF",
                RG = "RG",
                DataNascimento = "Data nascimento",
                Genero = "Gênero",
                EstadoCivil = "Estado civil",
                Profissao = "Profissão",
                Telefone1 = "Telefone 1",
                Telefone2 = "Telefone 2",
                Email = "E-mail",
                Cidade = "Cidade",
                Bairro = "Bairro",
                Logradouro = "Logradouro",
                Numero = "Número",
                Complemento = "Complemento",
                CEP = "CEP",
                Observacao ="Observação"
            };

            return titlulo;
        }

    }
}
