using Contract;
using System.Drawing;

namespace Services.Abstraction.DataServices
{
    public interface IGeneralService
    {
        ICollection<ColorDto> GetAllColor();
        ICollection<SizeDto> GetAllSize();

        ColorDto? GetColor(int id);
        ICollection<ColorDto> GetColor(string name);
        SizeDto? GetSize(int id);
        ICollection<SizeDto> GetSize(string name);


        void AddColor(string name, string code);
        void AddSize(string name);

        void RemoveColor(int colorId);
        void RemoveSize(int sizeId);

        void UpdaterColor(ColorDto color);
        void UpdateSize(SizeDto size);
    }
}
