using Contract;
using Domain.Entities;

namespace Services.Extenstions
{
    public static class ColorExtenstion
    {
        public static ColorDto ToColorDto(this Color color)
        {
            if (color == null)
                throw new ArgumentNullException(nameof(color));

            return new()
            {
                Id = color.Id,
                Code = color.Code,
                Name = color.Name,
            };
        }
        public static Color ToColorEntity(this ColorDto color)
        {
            if (color == null)
                throw new ArgumentNullException(nameof(color));

            return new()
            {
                Id = color.Id,
                Name = color.Name,
                Code = color.Code,
            };
        }

        public static List<ColorDto> ToColorDto(this List<Color> colors)
        {
            if (colors == null)
                throw new ArgumentNullException(nameof(colors));

             var colorDtos = new List<ColorDto>();
            foreach ( var color in colors) 
                colorDtos.Add(color.ToColorDto());
            
            return colorDtos;
        }
    }
}
