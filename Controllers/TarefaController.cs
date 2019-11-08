using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarefas.Models;

namespace Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private static readonly List<Tarefa> _tarefas = new List<Tarefa>();

        public TarefaController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tarefas);
        }

        [HttpPost]
        public IActionResult Post(Tarefa tarefa)
        {
            _tarefas.Add(tarefa);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Tarefa tarefaAlterada)
        {
            var tarefa = _tarefas.Find(t => t.Id == tarefaAlterada.Id);
            tarefa.Descricao = tarefaAlterada.Descricao;
            tarefa.EstaFeita = tarefaAlterada.EstaFeita;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var tarefaARemover = _tarefas.Find(t => t.Id == id);

            if (tarefaARemover == null)
                return NotFound();

            _tarefas.Remove(tarefaARemover);

            return Ok();
        }

        [HttpGet]
        public IActionResult Find(Guid id)
        {
            var tarefa = _tarefas.Find(t => t.Id == id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

    }
}
