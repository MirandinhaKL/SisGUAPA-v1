using NHibernate;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

/*
* Criado em: 15/11/2020
* Última alteração em: 
*/

namespace Repositorio.Classes
{
    public class AtendimentoDAO : RepositorioCrudDao<Atendimento>
    {
        public static bool Salvar(Atendimento atendimento)
        {
            var salvou = new AtendimentoDAO().SalvarOuAtualizar(atendimento);
            return salvou;
        }
              

        public static string Apagar(Atendimento atendimento)
            => new AtendimentoDAO().Excluir(atendimento);

        public static List<Atendimento> GetTodosRegistros(int entidadeId)
            => new AtendimentoDAO().Consultar(entidadeId).Where(k => k.Entidade.Id == entidadeId).ToList();

        public static Atendimento GetById(int atendimentoId)
            => new AtendimentoDAO().GetPorId(atendimentoId);

        public static List<Atendimento> GetAtendimentoDiaEspecifico(DateTime data, int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from a in Session.Query<Atendimento>()
                                    where a.DataAtendimentoInicio.Date == data.Date && a.Entidade.Id == entidadeId
                                    select a;
                        Transaction.Commit();
                        return dados.ToList();
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return null;
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao inserir entidade: " + exception.Message);
                    }
                }
            }
        }

        public static List<Atendimento> GetAtendimentoComTratamento(int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var dados = from a in Session.Query<Atendimento>()
                                    where a.Tratamento != null && a.Tratamento.EnumStatusTratamento != 0 && a.Entidade.Id == entidadeId
                                    select a;

                        Transaction.Commit();

                        var result = dados.ToList();

                        var dataFiltered = new List<Atendimento>();

                        foreach (var item in result)
                        {
                            var controles1 = item.Tratamento.ControlesMedicamento1?.ToList();
                            var controlesFiltrados1 = controles1?.FindAll(k => k.Medicamento?.Id == item.Tratamento.Medicamento1?.Id);

                            var controles2 = item.Tratamento.ControlesMedicamento2?.ToList();
                            var controlesFiltrados2 = controles2?.FindAll(k => k.Medicamento?.Id == item.Tratamento.Medicamento2?.Id);

                            var controles3 = item.Tratamento.ControlesMedicamento3?.ToList();
                            var controlesFiltrados3 = controles3?.FindAll(k => k.Medicamento?.Id == item.Tratamento.Medicamento3?.Id);

                            var controles4 = item.Tratamento.ControlesMedicamento4?.ToList();
                            var controlesFiltrados4 = controles4?.FindAll(k => k.Medicamento?.Id == item.Tratamento.Medicamento4?.Id);

                            var controles5 = item.Tratamento.ControlesMedicamento5?.ToList();
                            var controlesFiltrados5 = controles5?.FindAll(k => k.Medicamento?.Id == item.Tratamento.Medicamento5?.Id);

                            item.Tratamento.RemoveControlesMedicamento(1);
                            item.Tratamento.RemoveControlesMedicamento(2);
                            item.Tratamento.RemoveControlesMedicamento(3);
                            item.Tratamento.RemoveControlesMedicamento(4);
                            item.Tratamento.RemoveControlesMedicamento(5);

                            if (item.Tratamento.Medicamento1 != null) 
                                foreach (var cont1 in controlesFiltrados1)
                                    item.Tratamento.AddControleMedicamento1(cont1);

                            if (item.Tratamento.Medicamento2 != null)
                                foreach (var cont2 in controlesFiltrados2)
                                    item.Tratamento.AddControleMedicamento2(cont2);

                            if (item.Tratamento.Medicamento3 != null)
                                foreach (var cont3 in controlesFiltrados3)
                                    item.Tratamento.AddControleMedicamento3(cont3);

                            if (item.Tratamento.Medicamento4 != null)
                                foreach (var cont4 in controlesFiltrados4)
                                    item.Tratamento.AddControleMedicamento4(cont4);

                            if (item.Tratamento.Medicamento5 != null)
                                foreach (var cont5 in controlesFiltrados5)
                                    item.Tratamento.AddControleMedicamento5(cont5);

                            dataFiltered.Add(item);
                        }
                        return dataFiltered;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return null;
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao inserir entidade: " + exception.Message);
                    }
                }
            }
        }

        public static List<Atendimento> GetTratamentos(int entidadeId)
        {
            using (ISession Session = FluentySessionFactory.AbrirSession())
            {
                using (ITransaction Transaction = Session.BeginTransaction())
                {
                    try
                    {
                        var naoIniciado = 1;
                        var atendimentoRealizado = 0;

                        var atendimentos = (from a in Session.Query<Atendimento>()
                                            where a.Tratamento.EnumStatusTratamento != 0
                                            select a).ToList() ;

                        Transaction.Commit();

                        return atendimentos;
                    }
                    catch (Exception exception)
                    {
                        if (!Transaction.WasCommitted)
                        {
                            Transaction.Rollback();
                            return null;
                        }
                        Console.WriteLine(exception.Message);
                        throw new Exception("Erro ao inserir entidade: " + exception.Message);
                    }
                }
            }
        }


    }
}
