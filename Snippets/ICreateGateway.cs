namespace LiquidVisions.PanthaRhei.Generator.Domain.Gateways
{
    public interface ICreateGateway<in TEntity>
        where TEntity : class
    {
        bool Create(TEntity entity);
    }
}
