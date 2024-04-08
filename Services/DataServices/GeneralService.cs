﻿using Contract;
using Domain.Entities;
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

        private bool CanRemoveColor(Color color)
        {
            var varients = color.ColoredProducts.Select(pc => pc.Varients);
            if (varients.Count() != 0) return true;

            return varients.SelectMany(v => v, (v, varient) => varient.Quantity).Sum() != 0;
        }
        private bool CanRemoveSize(Size size) =>
             size.Varients.Sum(v => v.Quantity) != 0;

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

            if (color == null) throw new NotFoundException("Color");
            if (CanRemoveColor(color))
                throw new NotAllowedException("This Color has one or more Products in Store");
            _adminRepository.ColorRepository.Delete(color);
            _adminRepository.SaveChanges();
        }

        public void RemoveSize(int sizeId)
        {
            var size = _adminRepository.SizeRepository.Get(sizeId);

            if (size == null)
                throw new NotFoundException("Size");
            if (CanRemoveSize(size))
                throw new NotAllowedException("This Size has one or more Products in Store");

            _adminRepository.SizeRepository.Delete(size);
            _adminRepository.SaveChanges();
        }

        public void UpdaterColor(ColorDto color)
        {
            var colorEntity = _adminRepository.ColorRepository.Get(color.Id);
            if (colorEntity != null)
            {
                color.UpdateToEntity(colorEntity);
                _adminRepository.ColorRepository.Update(colorEntity);
                _adminRepository.SaveChanges();
            }
            else
                throw new NotFoundException("Color"); ;
        }

        public void UpdateSize(SizeDto size)
        {
            var sizeEntity = _adminRepository.SizeRepository.Get(size.Id);
            if (sizeEntity != null)
            {
                size.UpdateToEntity(sizeEntity);
                _adminRepository.SizeRepository.Update(sizeEntity);
                _adminRepository.SaveChanges();
            }
            else
                throw new NotFoundException("Size"); ;
        }
    }
}
