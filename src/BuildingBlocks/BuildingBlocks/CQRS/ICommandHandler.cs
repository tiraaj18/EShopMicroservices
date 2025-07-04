﻿namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand>: ICommandHandler<TCommand, MediatR.Unit>
        where TCommand : ICommand<MediatR.Unit>
    {
    }
    public interface ICommandHandler<in TCommand, TResponse>: MediatR.IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
