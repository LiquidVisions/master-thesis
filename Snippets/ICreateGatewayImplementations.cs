internal class GenericRepository<TEntity> : ICreateGateway<TEntity>, // ... other interfaces
    where TEntity : class
{
    // ... other code

    public bool Create(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        context.Entry(entity).State = EntityState.Added;

        return context.SaveChanges() >= 0;
    }

    // ... other code
}

internal class HarvestRepository : ICreateGateway<Harvest>, // ... other interfaces
{
    // .. other code 

    public bool Create(Harvest entity)
    {
        if(string.IsNullOrEmpty(entity.HarvestType))
        {
            throw new InvalidProgramException("Expected harvest type.");
        }

        string fullPath = Path.Combine(
            parameters.HarvestFolder,
            app.FullName,
            $"{file.GetFileNameWithoutExtension(entity.Path)}.{entity.HarvestType}");

        serializer.Serialize(entity, fullPath);

        return true;
    }
}