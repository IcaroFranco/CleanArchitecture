using CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace CleanArchitecture.Application.Abstraction.Handlers;

public interface IQuery<TResponse>
    : IRequest<Result<TResponse>> 
{ }
