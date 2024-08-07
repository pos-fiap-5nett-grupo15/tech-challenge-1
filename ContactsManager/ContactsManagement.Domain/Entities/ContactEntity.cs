namespace ContactsManagement.Domain.Entities;

public class ContactEntity : BaseEntity
{
    public ContactEntity() { }

    public ContactEntity(
        string nome,
        string email,
        int ddd,
        int telefone)
        : this()
    {
        Nome = nome;
        Email = email;
        Ddd = ddd;
        Telefone = telefone;
    }

    public string Nome { get; init; }
    public string Email { get; init; }
    public int Ddd { get; init; }
    public int Telefone { get; init; }
}
