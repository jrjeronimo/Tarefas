using System;

namespace Tarefas.Models
{
    public class Tarefa
    {
        public Tarefa()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool EstaFeita { get; set; }
    }
}