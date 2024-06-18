using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain;

public static class ServerErrors
{
    public static readonly Error Error500 = new(
        "InternalServerError",
        "Ocorreu um erro. Por favor tente novamamente mais tarde.");
}
