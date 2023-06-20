using Andreitoledo.UoW.Domain.Base;

namespace Andreitoledo.UoW.Domain
{
    public class Voo : EntityBase
    {

        // toda vez que criar uma nova instancia de voo vai criar uma lista de pessoas
        public Voo() 
        {
            Pessoas = new List<Pessoa>();
        }

        public String? Codigo { get; set; }
        public String? Nota { get; set; }
        public int Capacidade { get; set; } = 0;
        public int Disponibilidade { get; set; }
        
        // EF Relatioship
        public ICollection<Pessoa> Pessoas { get; set; }

        public void DecrementaDisponibilidade()
        {
            Disponibilidade -= 1;
        }

        public bool TemDisponibilidade()
        {
            return Disponibilidade > 0;
        }


    }
}
