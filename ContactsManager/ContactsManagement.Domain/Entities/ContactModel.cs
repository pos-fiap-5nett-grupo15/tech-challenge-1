namespace ContactsManagement.Domain.Entities;

public class ContactModel(
    int id,
    string nome,
    string email,
    int ddd,
    int telefone)
{
    public int Id { get; init; } = id;
    public string Nome { get; init; } = nome;
    public string Email { get; init; } = email;
    public int Ddd { get; init; } = ddd;
    public int Telefone { get; init; } = telefone;
}
