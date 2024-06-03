using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Usuarios.Shared;

public sealed class UsuarioRequest
{
    [Required, StringLength(150)]
    public required string Nome { get; set; }

    [Range(0, 999)] // o.O
    public int Idade { get; set; }

    public string? Email { get; set; }

    [Required, StringLength(50)]
    public required string Senha { get; set; }

    public bool Admin { get; set; }

    // Eventualmente vou adicionar o atributo [Atribute] para tratar as descrições dos campos.
}
