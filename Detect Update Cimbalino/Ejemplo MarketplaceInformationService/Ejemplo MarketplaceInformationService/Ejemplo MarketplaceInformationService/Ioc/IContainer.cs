namespace Ejemplo_MarketplaceInformationService.Ioc
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
