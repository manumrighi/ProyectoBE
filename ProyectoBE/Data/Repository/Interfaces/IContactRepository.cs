using ProyectoBE.Entities;
using ProyectoBE.Models;

namespace ProyectoBE.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public Contact? GetById(int contactId);
        public List<Contact> GetAll();
        public void Create(CreateAndUpdateContactDto dto);
        public void Update(CreateAndUpdateContactDto dto);
        public void Delete(int id);
        public void Archive(int id);
    }
}
