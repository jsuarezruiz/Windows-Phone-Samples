namespace Ejemplo_Cimbalino.Ioc
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
