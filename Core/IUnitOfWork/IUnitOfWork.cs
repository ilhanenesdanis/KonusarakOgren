namespace Core.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        int saveChanges();
    }
}
