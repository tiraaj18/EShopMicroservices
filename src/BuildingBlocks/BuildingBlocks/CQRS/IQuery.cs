namespace BuildingBlocks.CQRS
{
    public interface IQuery<out TResponse>: MediatR.IRequest<TResponse> where TResponse : notnull
    {
    }
}
