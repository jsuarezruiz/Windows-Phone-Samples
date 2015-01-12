namespace Ejemplo_Xbox_Music.Ioc
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
