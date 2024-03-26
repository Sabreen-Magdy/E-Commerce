using Contract;
using Domain.Entities;

namespace Services.Extenstions;

public static class CustomerExtenstion
{
    public static Customer ToCustomerEntity(this CustomerAddDto customer)
    {
        if (customer == null) 
            throw new ArgumentNullException(nameof(customer));
       
        return new Customer
        {
            Name = customer.Name,
            Password = customer.Password,
            Email = customer.Email,
            Image = customer.Image,
            Phone = customer.Phone,
        };
    }

    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));
       
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Password = customer.Password,
            Email = customer.Email,
            Image = customer.Image,
            Phone = customer.Phone,
        };
    }

    public static List<CustomerDto> ToCustomerDto(this List<Customer> customers)
    {
        if (customers == null)
            throw new ArgumentNullException(nameof(customers));
        
        var customersDto = new List<CustomerDto>();
        
        foreach (var customer in customers)
            customersDto.Add(customer.ToCustomerDto());
        
        return customersDto;
    }
}
