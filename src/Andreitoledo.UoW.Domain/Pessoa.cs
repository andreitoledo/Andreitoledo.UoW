using Andreitoledo.UoW.Domain.Base;
using System.Text.Json.Serialization;

namespace Andreitoledo.UoW.Domain
{
    public class Pessoa : EntityBase
    {
        public Pessoa()
        {
            
        }

        public String? Nome { get; set; }
        public Guid? VooId { get; set; }

        [JsonIgnore]
        public Voo? Voo { get; set; }



    }
}