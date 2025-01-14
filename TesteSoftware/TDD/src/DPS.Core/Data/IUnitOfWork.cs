namespace DPS.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}