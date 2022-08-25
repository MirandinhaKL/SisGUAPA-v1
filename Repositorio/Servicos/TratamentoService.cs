using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Servicos
{
    public class TratamentoService : ITratamentoService
    {
        string ITratamentoService.MensagemTooltip => "Imprime um arquivo com os compromissos agendados na data selecionada no calendário.";
    }
}
