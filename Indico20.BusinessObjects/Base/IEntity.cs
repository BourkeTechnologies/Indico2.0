namespace Indico20.BusinessObjects.Base
{
    public interface IEntity
    {
        int ID { get; }
        void Add(UnitOfWork unit =null);
        void Delete(UnitOfWork unit = null);
        void Update(UnitOfWork unit = null);
    }
}
