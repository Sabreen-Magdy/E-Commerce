using Contract;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;


namespace Services.DataServices
{
    public class GeneralService : IGeneralService
    {
        private readonly IAdminRepository _adminRepository;
        public GeneralService(IAdminRepository adminRepository) =>
            _adminRepository = adminRepository;

        public void AddColor(string name, string code)
        {
            _adminRepository.ColorRepository.Add(new()
            {
                Code = code,
                Name = name
            });
            _adminRepository.SaveChanges();
        }

        public void AddSize(string name)
        {
            _adminRepository.SizeRepository.Add(new()
            {
                Name = name
            });
            _adminRepository.SaveChanges();
        }

        public ICollection<ColorDto> GetAllColor() =>
            _adminRepository.ColorRepository.GetAll().ToColorDto();

        public ICollection<SizeDto> GetAllSize() =>
            _adminRepository.SizeRepository.GetAll().ToSizeDto();

        public ColorDto? GetColor(int id) =>
            _adminRepository.ColorRepository.Get(id)!.ToColorDto();

        public ICollection<ColorDto> GetColor(string name) =>
            _adminRepository.ColorRepository.Get(name)!.ToColorDto();

        public SizeDto? GetSize(int id) =>
            _adminRepository.SizeRepository.Get(id)!.ToSizeDto();

        public ICollection<SizeDto> GetSize(string name) =>
            _adminRepository.SizeRepository.Get(name)!.ToSizeDto();

        public void RemoveColor(int colorId)
        {
            var color = _adminRepository.ColorRepository.Get(colorId);

            if (color != null)
            {
                _adminRepository.ColorRepository.Delete(color);
                _adminRepository.SaveChanges();
            }
            else
                throw new NotFoundException("Color");
        }

        public void RemoveSize(int sizeId)
        {
            var size = _adminRepository.SizeRepository.Get(sizeId);

            if (size != null)
            {
                _adminRepository.SizeRepository.Delete(size);
                _adminRepository.SaveChanges();
            }
            else
                throw new NotFoundException("Size");
        }

        public void UpdaterColor(ColorDto color)
        {
            _adminRepository.ColorRepository.Update(color.ToColorEntity());
            _adminRepository.SaveChanges();
            //if (_adminRepository.ColorRepository.Get(color.Id) != null)
            //{
               
            //}
            //else
            //    throw new NotFoundException("Color"); ;
        }

        public void UpdateSize(SizeDto size)
        {
            _adminRepository.SizeRepository.Update(size.ToSizeEntity());
            _adminRepository.SaveChanges();
            //    if (_adminRepository.SizeRepository.Get(size.Id) != null)
            //    {

            //    }
            //    else
            //        throw new NotFoundException("Size"); ;
        }
    }
}
