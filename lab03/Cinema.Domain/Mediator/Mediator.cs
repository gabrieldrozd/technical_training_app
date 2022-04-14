using Cinema.Domain.Features.Command;
using Cinema.Domain.Features.Query;

namespace Cinema.Domain.Mediator;

public class Mediator : IMediator
{
    private readonly IDependencyResolver _dependencyResolver;

    public Mediator(IDependencyResolver dependencyResolver)
    {
        _dependencyResolver = dependencyResolver;
    }
    
    public Result Command<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handler = _dependencyResolver.ResolveOrDefault<ICommandHandler<TCommand>>();
        if (handler == null)
            throw new InvalidOperationException($"Command of type '{command.GetType()}' has not registered handler.");

        return handler.Handle(command);
    }

    public TResponse Query<TResponse>(IQuery<TResponse> query)
    {
        return (TResponse) GetType()
            .GetMethods()
            .First(x => x.Name == "Query" && x.GetGenericArguments().Length == 2)
            .MakeGenericMethod(query.GetType(), typeof(TResponse))
            .Invoke(this, new object[] {query});
    }

    public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
    {
        var handler = _dependencyResolver.ResolveOrDefault<IQueryHandler<TQuery, TResponse>>();
        if (handler == null)
            throw new InvalidOperationException($"Query of type '{query.GetType()}' has not recognised handler.");

        return handler.Handle(query);
    }
}