using Contract;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Services.Abstraction.DataServices;
using Services.Extenstions;

namespace Services.DataServices
{
    public class ProductService : IProductService
    {
        private readonly IAdminRepository _repository;

        public ProductService(IAdminRepository repository)
            => _repository = repository;

        private ProductDto Map(Product product)
        {
            //var varients = GetVarients(product.Id);
            var coloredProducts = _repository.ProductColerdRepository.GetByProduct(product.Id);
            
            double price = coloredProducts is null || coloredProducts.Count == 0 ? 
                    0 : coloredProducts.SelectMany(
                        c => c.Varients, (c, v) => v.Price / c.Varients.Count).Sum();
            //var coloresImages = GetColoresImages(product.Id);

            var image = coloredProducts is null || coloredProducts.Count == 0 ?
                    null : coloredProducts[0].Image;
            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = price,
                Image = image
            };
        }
        private List<ProductDto> Map(List<Product> products) =>
            products.Select(p => Map(p)).ToList();
        private void DeleteImage(string? imgPath)
        {
            if (imgPath != null)
                Static.DeleteImage(imgPath);
        }
        private void DeleteImage(List<string?>? imgPaths)
        {
            if (imgPaths != null)
                foreach (var imgPath in imgPaths)
                    DeleteImage(imgPath);
            
        }

        public void Add(ProductNewDto product)
        {
            // Save the Main Product Data
            Product productEntity = product.ToProductEntity();
            _repository.ProductRepository.Add(productEntity);
            _repository.SaveChanges();

            // Assign Product To Category
            foreach (int id in product.Categories)
            {
                _repository.ProductCategoryRepository.Add(new()
                {
                    CategoryId = id,
                    ProductId = productEntity.Id
                });
                _repository.SaveChanges();
            }
            //for (int i = 0; i < product.ProductVariants.Count; i++)
            //{
            //   product.Images[i] .Image.FileName = productEntity.Id.ToString() + "_" + product.ProductVariants[i].ColorId + "." + product.Images[i].Image.FileName.Split('.').Last();
            //}
            // Save Product Images
            var productColoredLis = product.Images
                .ToColoredProductEntity(productEntity.Id);
            _repository.ProductColerdRepository
                .AddRange(productColoredLis);
            _repository.SaveChanges();

            // Save Product Varients
            _repository.ProductVarientRepository
                .AddRange(product.ProductVariants
                .ToProductVariantEntity(productEntity.Id));
            _repository.SaveChanges();

        //string UploadDirectory = "wwwroot/images";
        //    for (int i =0; i<product.Images.Count; i++)
        //    {
        //        var file = product.Images[i].Image;
        //        var fileName = $"{productEntity.Id}_{product.ProductVariants[i].ColorId}.{file.FileName.Split('.').Last()}";
        //        var filePath = Path.Combine(UploadDirectory, fileName);
        //         SaveFileAsync(file, filePath);

        //    }
        }
        //private  void SaveFileAsync(IFormFile file, string filePath)
        //{
        //    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //         file.CopyTo(stream);
        //    }
        //}
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
            var imgs = product.ColoredProducts.Select(cp => cp.Image).ToList();

            _repository.ProductRepository.Delete(product);
            _repository.SaveChanges();

            DeleteImage(imgs);
        }

        public void DeleteCategory(int id)
        {
            var prodCat = _repository.ProductCategoryRepository.Get(id);
           
            if (prodCat is null)
                throw new NotFoundException("ProductCategory");
            var imgs = prodCat.Product.ColoredProducts.Select(cp => cp.Image).ToList();

            _repository.ProductCategoryRepository.Delete(prodCat);
            _repository.SaveChanges();

            DeleteImage(imgs);
        }

        public void DeleteCategory(int productId, int categoryId)
        {
            var prodCat = _repository.ProductCategoryRepository
                                .Get(productId, categoryId);
           
            if (prodCat is null)
                throw new NotFoundException("ProductCategory");
            var imgs = prodCat.Product.ColoredProducts.Select(cp => cp.Image).ToList();

            _repository.ProductCategoryRepository.Delete(prodCat);
            _repository.SaveChanges();


            DeleteImage(imgs);
        }

        public void DeleteColor(int id)
        {
            var prodColor = _repository.ProductColerdRepository.Get(id);
           
            if (prodColor is null)
                throw new NotFoundException("ProductColored");
            var img = prodColor.Image;

            _repository.ProductColerdRepository.Delete(prodColor);
            _repository.SaveChanges();

            DeleteImage(img);
        }

        public void DeleteColor(int productId, int colorId)
        {
            var prodColor = _repository.ProductColerdRepository
                .GetAll().Find(e => e.ProductId == productId
                && e.ColorId == colorId);
           
            if (prodColor is null)
                throw new NotFoundException("ProductColored");
            var img = prodColor.Image;
            _repository.ProductColerdRepository.Delete(prodColor);
            _repository.SaveChanges();

            DeleteImage(img);
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
            if (productColors == null)
                throw new NotFoundException("Products");
            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByColorName(string color)
        {
            var productColors = _repository.ProductColerdRepository
                .GetAll().FindAll(e => e.Color.Code == color);
            if (productColors == null)
                throw new NotFoundException("Products");
            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByColorCode(string name)
        {
            var productColors = _repository.ProductColerdRepository
              .GetAll().FindAll(e => e.Color.Name == name);

            return Map(productColors.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByGetegory(int id)
        {
            var productCategs = _repository.ProductCategoryRepository
               .GetAll().FindAll(e => e.CategoryId == id);
            if (productCategs == null)
                throw new NotFoundException("Products");

            return Map(productCategs.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByGetegory(string name)
        {
            var productCategs = _repository.ProductCategoryRepository
              .GetAll().FindAll(e => e.Category.Name == name);
            if (productCategs == null)
                throw new NotFoundException("Products");

            return Map(productCategs.Select(e => e.Product).ToList());
        }

        public List<ProductDto> GetByPrice(double price)
        {
            var productVarients = _repository.ProductVarientRepository
                 .GetAll().FindAll(e => e.UnitPrice == price);
            if (productVarients == null)
                throw new NotFoundException("Products");
            return Map(productVarients.Select(e => e.ColoredProduct.Product).ToList());
        }

        public List<ProductDto> GetByQuantity(int quantity)
        {
            var productVarients = _repository.ProductVarientRepository
                .GetAll().FindAll(e => e.Quantity == quantity); 
            if (productVarients == null)
                throw new NotFoundException("Products");

            return Map(productVarients.Select(e => e.ColoredProduct.Product).ToList());
        }

        public List<ProductDto> GetByRate(float rate)
        {
            var products = _repository.ProductRepository
                 .GetAll().FindAll(e => e.AvgRate == rate);
            if (products == null)
                throw new NotFoundException("Products");

            return Map(products);
        }

        public List<ColoredProuctDto> GetColoresImages(int productId)
        {
            var product = _repository.ProductRepository.Get(productId);
            if (product is null)
                throw new NotFoundException("Prodect");

            return _repository.ProductColerdRepository
                .GetByProduct(productId).ToColoredProductDto();                       
        }

        public List<CustomerReviewDto> GetReviews(int productId)
        {
            var product = Get(productId);
            if (product is null)
                throw new NotFoundException("Prodect");

            return _repository.ReviewRepository
                .GetAllReviewByProductId(productId).ToCustomerReview();
        }

        public List<ProductVariantDto> GetVarients(int productId)
        {
            var product = _repository.ProductRepository.Get(productId);
            if (product is null)
                throw new NotFoundException("Prodect");

            var coloredProducts = product.ColoredProducts;
            List<ProductVariantDto> products = new List<ProductVariantDto>();

            if (coloredProducts is null)
                throw new NotFoundException("ColoredProdect");

            var res = coloredProducts.Select(cp => cp.Varients
                            .ToList().ToProductVariantDto());
   
            return res.SelectMany(innerList => innerList).ToList();
        }
        public ProductDetailsDto GetDetails(int productId)
        {
            var product = _repository.ProductRepository.Get(productId);
            if (product is null)
                throw new NotFoundException("Prodect");
          
            return product.ToProductDetailsDto();
        }

        private Product UpdateProduct(Product product,
                            Dictionary<Properties, string> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.Name:
                        product.Name = item.Value;
                        break;
                    case Properties.Description:
                        product.Description = item.Value;
                        break;
                    case Properties.AddingDate:
                        product.AddingDate = DateTime.Parse(item.Value);
                        break;

                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return product;
        }
        public void Update(int id, Dictionary<Properties, string> newValues)
        {
            var product = _repository.ProductRepository.Get(id);
            if (product is null)
                throw new NotFoundException("Product");
            else
            {
                _repository.ProductRepository.Update(UpdateProduct(product, newValues));
                _repository.SaveChanges();
            }
        }


        private ProductVarient UpdateVarient(ProductVarient product,
                           Dictionary<Properties, string> newValues)
        {
            foreach (var item in newValues)
            {
                switch (item.Key)
                {
                    case Properties.SizeId:
                        product.SizeId = int.Parse(item.Value);
                        break;
                    case Properties.UnitPrice:
                        product.UnitPrice = int.Parse(item.Value);
                        break;
                    case Properties.Quantity:
                        product.Quantity = int.Parse(item.Value);
                        break;
                    case Properties.ProductId:
                        product.ProductId = int.Parse(item.Value);
                        break;
                    case Properties.ColorId:
                        product.ColorId = int.Parse(item.Value);
                        break;

                    default:
                        throw new PropertyException(item.Key.ToString());
                }
            }
            return product;
        }
        public void UpdateVarient(int id, Dictionary<Properties, string> newValues)
        {
            var product = _repository.ProductVarientRepository.Get(id);
            if (product is null)
                throw new NotFoundException("Product");
            else
            {
                _repository.ProductVarientRepository
                    .Update(UpdateVarient(product, newValues));
                _repository.SaveChanges();
            }
        }

        public int GetNumberProducts() => _repository.ProductRepository.GetLength();

        
    }
}