
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
            CustomerId =review.CustomerId,
            Date = review.Date,
};
    }
    public static Review ToReviewEntity(this CustomerReviewDto reviewDto)
    {
        if (reviewDto == null)
            throw new ArgumentNullException(nameof(reviewDto));

        return new Review
        {
            ProductId = reviewDto.ProductId,
            Rate = reviewDto.Rate,
            Comment = reviewDto.Review,
            Date =reviewDto.Date,
            CustomerId=reviewDto.CustomerId
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
    //public static List<Review> ToReviewEntities(this List<CustomerReviewDto> reviewsDto)
    //{
    //    if (reviewsDto == null)
    //        throw new ArgumentNullException(nameof(reviewsDto));

    //    var reviews = new List<Review>();
    //    foreach (var item in reviewsDto)
    //        reviews.Add(item.ToReviewEntity());

    //    return reviews;
    //}

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
            Date = review.Date,
};
    }
    public static Review ToReviewEntity(this ProductReviewDto reviewDto)
    {
        if (reviewDto == null)
            throw new ArgumentNullException(nameof(reviewDto));

        return new Review
        {
            ProductId = reviewDto.ProductId,
            Rate = reviewDto.Rate,
            Comment = reviewDto.Review,
            Date = reviewDto.Date,
            CustomerId = reviewDto.CustomertId
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
