using Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.DataServices
{
   public interface ISallerService
    {
        void add(Saller sel);
        Saller? GetByEmail(string email);
        
    }
}
