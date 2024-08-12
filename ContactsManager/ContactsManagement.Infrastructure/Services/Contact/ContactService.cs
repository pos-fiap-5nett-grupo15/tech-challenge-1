using ContactsManagement.Domain.Entities;
using ContactsManagement.Infrastructure.UnitOfWork;

namespace ContactsManagement.Infrastructure.Services.Contact
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
            
        public ContactService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(ContactEntity model)
        {
            await _unitOfWork.ContactRepository.CreateAsync(model);
        }

        public async Task DeleteByIdAsync(int id)
        {
           await _unitOfWork.ContactRepository.DeleteByIdAsync(id);
        }

        public async Task<ContactEntity?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ContactRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ContactEntity>> GetListPaginatedByFiltersAsync(int? ddd, int currentIndex, int pageSize)
        {
            return await _unitOfWork.ContactRepository.GetListPaginatedByFiltersAsync(ddd, currentIndex, pageSize);
        }

        public async Task UpdateByIdAsync(int id, string? nome, string? email, int? ddd, int? telefone)
        {
            await _unitOfWork.ContactRepository.UpdateByIdAsync(id, nome, email, ddd, telefone);
        }
    }
}
