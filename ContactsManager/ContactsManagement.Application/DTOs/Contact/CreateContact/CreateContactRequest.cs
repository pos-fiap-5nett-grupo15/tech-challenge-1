namespace ContactsManagement.Application.DTOs.Contact.CreateContact;

public class CreateContactRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Ddd { get; set; }
    public int Telefone { get; set; }
}
