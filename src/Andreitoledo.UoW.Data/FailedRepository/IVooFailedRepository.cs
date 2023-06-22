namespace Andreitoledo.UoW.Data.FailedRepository

{
    public interface IVooFailedRepository
    {
        Task DecrementarVaga(Guid? vooId);            
    }    
}







