using Domain.Repositories;
using Services.Abstraction.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    internal class SalleryService : ISallerService
    {
        private IAdminRepository _repositoryAdmin;

        public SalleryService(IAdminRepository repositoryAdmin)
        {
            _repositoryAdmin = repositoryAdmin;
        }
    }
}
