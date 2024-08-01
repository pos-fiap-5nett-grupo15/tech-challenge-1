namespace ContactsManagement.Application.DTOs.Contact.UpdateContactById;

public class UpdateContactByIdRequest
{
    public int? Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public int? Ddd { get; set; }
    public int? Telefone { get; set; }
}
