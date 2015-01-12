namespace Ejemplo_Flurry_Analytics.Ioc
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
