using ProyectoBE.Data.Repository.Interfaces;
using ProyectoBE.Entities;
using ProyectoBE.Models;

namespace ProyectoBE.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private AgendaContext _context;
        private readonly IMapper _mapper;
    }
    
   
}
