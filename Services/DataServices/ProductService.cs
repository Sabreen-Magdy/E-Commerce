using Contract.ClientDto;
using Contract.Product;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using System.Diagnostics;

namespace Services.DataServices
{
    public class ProductService : IProductService
    {
        private readonly IAdminRepository _repository;

        public ProductService(IAdminRepository repository)
            => _repository = repository;
       
        private ProductDto Map(Product product)
        {
            var varients = GetVarients(product.Id);

            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = varients.Select(varient => varient.Price).Sum() / varients.Count,
                Image = GetColoresImages(product.Id)[0].Image
            };
        }
        private List<ProductDto> Map(List<Product> products)
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
                productDtos.Add(Map(product));

            return productDtos;
        }

        public void Add(ProductNewDto product)
        {
            // Save the Main Product Data
            Product productEntity = product.ToProductEntity();
            _repository.ProductRepository.Add(productEntity);
            _repository.SaveChanges();

            // Save Product Images
            var productColoredLis = product.Images
                .ToColoredProductEntity(productEntity.Id);
            _repository.ProductColerdRepository
                .AddRange(productColoredLis);
            _repository.SaveChanges();

            // Save Product Varients
            _repository.ProductVarientRepository
                .AddRange(product.ProductVariants
                .ToProductVariantEntity(productColoredLis.GetIds()));
            _repository.SaveChanges();
        }

        public void AddColor(ProductColoredNewDto productColored)
        {
            _repository.ProductColerdRepository
                .Add(productColored.ToColoredProductEntity());

            _repository.SaveChanges();
        }

        public void AddVarient(ProductVariantNewDto productVarient)
        {
            _repository.ProductVarientRepository
               .Add(productVarient.ToProductVariantEntity());

            _repository.SaveChanges();
        }

        public void AssignCategory(int productId, int categoryId)
        {
            _repository.ProductCategoryRepository.Add(new()
            {
                CategoryId= categoryId,
                ProductId= productId
            });

            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            Product? product = _repository.ProductRepository.Get(id);
            if (product is null)
                throw new NotFoundException("Product");
            
            _repository.ProductRepository.Delete(product);
            _repository.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var prodCat = _repository.ProductCategoryRepository.Get(id);
           
            if (prodCat is null)
                throw new NotFoundException("ProductCategory");

            _repository.ProductCategoryRepository.Delete(prodCat);
            _repository.SaveChanges();
        }

        public void DeleteCategory(int productId, int categoryId)
        {
            var prodCat = _repository.ProductCategoryRepository
                .GetAll().Find(e => e.ProductId == productId 
                && e.CategoryId == categoryId);
           
            if (prodCat is null)
                throw new NotFoundException("ProductCategory");

            _repository.ProductCategoryRepository.Delete(prodCat);
            _repository.SaveChanges();
        }

        public void DeleteColor(int id)
        {
            var prodColor = _repository.ProductColerdRepository.Get(id);
           
            if (prodColor is null)
                throw new NotFoundException("ProductColored");

            _repository.ProductColerdRepository.Delete(prodColor);
            _repository.SaveChanges();
        }

        public void DeleteColor(int productId, int colorId)
        {
            var prodColor = _repository.ProductColerdRepository
                .GetAll().Find(e => e.ProductId == productId
                && e.ColorId == colorId);
           
            if (prodColor is null)
                throw new NotFoundException("ProductColored");

            _repository.ProductColerdRepository.Delete(prodColor);
            _repository.SaveChanges();
        }


        public void DeleteVarient(int id)
        {
            var prodVarient = _repository.ProductVarientRepository.Get(id);

            if (prodVarient is null)
                throw new NotFoundException("ProdectVarient");

            _repository.ProductVarientRepository.Delete(prodVarient);
            _repository.SaveChanges();
        }

        public ProductDto? Get(int id)
        {
            var product = _repository.ProductRepository.Get(id);

            if (product is null)
                throw new NotFoundException("Prodect");

            return Map(product);
        }

        public List<ProductDto> Get(string name)
        {
            var products = _repository.ProductRepository.Get(name);

            if (products is null)
                throw new NotFoundException("ProdectVarient");
            
            return Map(products);
        }

        public List<ProductDto> GetAll()
        {
            var products = _repository.ProductRepository.GetAll();

            if (products is null)
                throw new NotFoundException("Prodect");

            return Map(products);
        }

        public List<ProductDto> GetByColor(int id)
        {
            var productColors = _repository.ProductColerdRepository
                .GetAll().FindAll(e => e.ColorId == id);

            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByColor(System.Drawing.Color color)
        {
            var productColors = _repository.ProductColerdRepository
                .GetAll().FindAll(e => e.Color.Code == color);

            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByColor(string name)
        {
            var productColors = _repository.ProductColerdRepository
              .GetAll().FindAll(e => e.Color.Name == name);

            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByGetegory(int id)
        {
            var productCategs = _repository.ProductCategoryRepository
               .GetAll().FindAll(e => e.CategoryId == id);

            return Map(productCategs.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByGetegory(string name)
        {
            var productCategs = _repository.ProductCategoryRepository
              .GetAll().FindAll(e => e.Category.Name == name);

            return Map(productCategs.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByPrice(double price)
        {
            var productVarients = _repository.ProductVarientRepository
                 .GetAll().FindAll(e => e.UnitPrice == price);
            
            return Map(productVarients.Select(e => e.ColoredProduct.Product).ToList());
        }

        public List<ProductDto> GetByQuantity(int quantity)
        {
            var productVarients = _repository.ProductVarientRepository
                .GetAll().FindAll(e => e.Quantity == quantity);

            return Map(productVarients.Select(e => e.ColoredProduct.Product).ToList());
        }

        public List<ProductDto> GetByRate(float rate)
        {
            var products = _repository.ProductRepository
                 .GetAll().FindAll(e => e.AvgRate == rate);

            return Map(products);
        }

        public List<ColoredProuctDto> GetColoresImages(int productId)
        {
            //var product = Get(productId); 
            // if (product is null)
            //     throw new NotFoundException("Prodect");

            //var productColorLis = _repository.ProductColerdRepository
            //     .GetByProduct(productId);

            // Map()
            throw new NotImplementedException();
        }

        public List<ProductReviewDto> GetReviews(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductVariantDto> GetVarients(int productId)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Dictionary<Properties, string> newValues)
        {
            throw new NotImplementedException();
        }

        public void UpdateVarient(int id, Dictionary<Properties, string> newValues)
        {
            throw new NotImplementedException();
        }
    }
}