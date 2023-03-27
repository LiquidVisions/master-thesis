internal class GenericRepository<TEntity> : ICreateGateway<TEntity>, IGetGateway<TEntity>, IUpdateGateway<TEntity>, IDeleteGateway<TEntity>
    where TEntity : class
{
    ...

    public IEnumerable<TEntity> GetAll()
    {
        return context.Set<TEntity>();
    }

    public TEntity GetById(object id)
    {
        return context.Set<TEntity>()
            .Find(id);
    }

    ...
}