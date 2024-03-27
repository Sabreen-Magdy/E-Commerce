using Contract;
using Domain.Entities;

namespace Services.Extenstions
{
    public static class SizeExtenstiom
    {
        public static SizeDto ToSizeDto(this Size size)
        {
            if (size == null)
                throw new ArgumentNullException(nameof(size));

            return new()
            {
                Id = size.Id,
                Size = size.Name,
            };
        }

        public static Size ToSizeEntity(this SizeDto size)
        {
            if (size == null)
                throw new ArgumentNullException(nameof(size));

            return new()
            {
                Id = size.Id,
                Name = size.Size,
            };
        }
        public static void UpdateToEntity(this SizeDto size, Size sourse)
        {
            if (size == null || sourse == null)
                throw new ArgumentNullException(nameof(size));

            sourse.Name = size.Size;
        }

        public static List<SizeDto> ToSizeDto(this List<Size> sizes)
        {
            if (sizes == null)
                throw new ArgumentNullException(nameof(sizes));

            var sizeDtos = new List<SizeDto>();
            foreach (var size in sizes)
                sizeDtos.Add(size.ToSizeDto());

            return sizeDtos;
        }
    }
}
