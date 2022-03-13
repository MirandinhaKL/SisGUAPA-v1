using Repositorio.DAO;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 10/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class HospedagemDAO : RepositorioCrudDao<Hospedagem>
    {
        public static bool Salvar(Hospedagem hospedagem)
        {
            var salvou = false;
            salvou = new HospedagemDAO().SalvarOuAtualizar(hospedagem);

            if (salvou)
            {
                if (hospedagem.DataFinal != null && hospedagem.DataFinal.Date != DateTime.MinValue)
                    hospedagem.Animal.Hospedado = false;
                else
                    hospedagem.Animal.Hospedado = true;
                
                salvou = new AnimalDAO().SalvarOuAtualizar(hospedagem.Animal);
            }
            return salvou;
        }

        public static string Apagar(Hospedagem hospedagem)
            => new HospedagemDAO().Excluir(hospedagem);

        public static List<Hospedagem> GetTodosRegistros(int entidadeId)
            => new HospedagemDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Hospedagem GetById(int hospedagemId)
            => new HospedagemDAO().GetPorId(hospedagemId);
    }
}
