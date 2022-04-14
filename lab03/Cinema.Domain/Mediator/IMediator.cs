using Cinema.Domain.Features.Command;
using Cinema.Domain.Features.Query;

namespace Cinema.Domain.Mediator;

public interface IMediator
{
    Result Command<TCommand>(TCommand command) where TCommand : ICommand;
    TResponse Query<TResponse>(IQuery<TResponse> query);
    TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
}