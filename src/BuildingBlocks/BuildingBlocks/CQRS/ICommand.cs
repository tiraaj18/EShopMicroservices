namespace BuildingBlocks.CQRS
{
    public interface ICommand<out TResponse>: MediatR.IRequest<TResponse>
    {
    }

    public interface ICommand: ICommand<MediatR.Unit>
    {
    }
}
