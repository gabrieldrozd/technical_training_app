namespace Cinema.Domain.Mediator;

public interface IDependencyResolver
{
    T ResolveOrDefault<T>() where T : class;
}