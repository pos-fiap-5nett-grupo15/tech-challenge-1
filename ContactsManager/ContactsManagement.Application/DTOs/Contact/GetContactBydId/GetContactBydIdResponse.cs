namespace ContactsManagement.Application.DTOs.Contact.GetContactBydId;

public class GetContactBydIdResponse : BaseReponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Ddd { get; set; }
    public int Telefone { get; set; }
}
