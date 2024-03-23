
using Contract;
using Domain.Entities;
using System.Collections.Generic;

namespace Services.Extenstions;

public static class ReviewExtenstion
{
    public static CustomerReviewDto ToCustomerReview(this Review review)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review));

        return new()
        {
            ProductId = review.ProductId,
            Rate = review.Rate,
            Review = review.Comment,
            ProductName = review.Product.Name,
        };
    }
    public static List<CustomerReviewDto> ToCustomerReview(this List<Review> reviews)
    {
        if (reviews == null)
            throw new ArgumentNullException(nameof(reviews));

        var reviewsDto = new List<CustomerReviewDto>();
        foreach (var item in reviews)
            reviewsDto.Add(item.ToCustomerReview());

        return reviewsDto;
    }

    public static ProductReviewDto ToProductReview(this Review review)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review));

        return new()
        {
            CustomertId = review.CustomerId,
            Rate = review.Rate,
            Review = review.Comment,
            CustomerName = review.Customer.Name,
        };
    }
    public static List<ProductReviewDto> ToProductReview(this List<Review> reviews)
    {
        if (reviews == null)
            throw new ArgumentNullException(nameof(reviews));

        var reviewsDto = new List<ProductReviewDto>();
        foreach (var item in reviews)
            reviewsDto.Add(item.ToProductReview());

        return reviewsDto;
    }
}
