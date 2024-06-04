namespace NLayerCore.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
