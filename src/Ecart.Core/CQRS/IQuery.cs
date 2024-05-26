﻿using MediatR;

namespace Ecart.Core.CQRS;

/// <summary>
/// Execute Query.
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}