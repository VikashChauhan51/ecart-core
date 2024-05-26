using MediatR;

namespace Ecart.Core.CQRS;


/// <summary>
/// Execute ICommand.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}


/// <summary>
/// Execute ICommand.
/// </summary>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
