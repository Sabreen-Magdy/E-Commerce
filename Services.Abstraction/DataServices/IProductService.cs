﻿using Contract;
using Domain.Enums;

namespace Services.Abstraction.DataServices;

public interface IProductService
{
    #region Retrive Operations 
   
    List<ProductDto> GetAll();
    ProductDto? Get(int id);
    #region Search&Filter

    List<ProductDto> Get(string name);
    List<ProductDto> GetByRate(float rate);
    List<ProductDto> GetByPrice(double price);
    List<ProductDto> GetByQuantity(int quantity);
    List<ProductDto> GetByColor(int id);
    List<ProductDto> GetByColor(System.Drawing.Color color);
    List<ProductDto> GetByColor(string name);
    List<ProductDto> GetByGetegory(int id);
    List<ProductDto> GetByGetegory(string name);

    List<ProductVariantDto> GetVarients(int productId);
    List<ColoredProuctDto> GetColoresImages(int productId);

    List<ProductReviewDto> GetReviews(int productId);
    #endregion

    #endregion

    #region Create Operations

    void Add(ProductNewDto product);
    void AddVarient(ProductVariantNewDto productVarient);
    void AddColor(ProductColoredNewDto productColored);
    void AssignCategory(int productId, int categoryId);

    #endregion

    #region Update Operations
    
    void Update(int id, Dictionary<Properties, string> newValues);
    void UpdateVarient(int id, Dictionary<Properties, string> newValues);

    #endregion

    #region Delete Operations

    void Delete(int id);
    void DeleteVarient(int id);
    
    void DeleteColor(int id);
    void DeleteColor(int productId, int colorId);

    void DeleteCategory(int id);
    void DeleteCategory(int productId, int categoryId);

    #endregion
}

