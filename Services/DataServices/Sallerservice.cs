using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public class SalleryService : ISallerService
    {
        private IAdminRepository _repositoryAdmin;

        public SalleryService(IAdminRepository repositoryAdmin)
        {
            _repositoryAdmin = repositoryAdmin;
        }

        public void add(Saller sel)
        {
            _repositoryAdmin.SallerRepository.Add(sel);
            _repositoryAdmin.SaveChanges();
        }

        public Saller? GetByEmail(string email)
        {
            return _repositoryAdmin.SallerRepository.GetAll().Find(a => a.Email == email);
        }
    }
}
