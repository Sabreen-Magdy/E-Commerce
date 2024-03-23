﻿using Contract.Order;
using Domain.Entities;
using Domain.Repositories;
using Services.Abstraction.DataServices;
using Services.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public class OrderService : IOrderService
    {
        private readonly IAdminRepository _repository;

        public OrderService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public void Add(OrderDto orderDto)
        {
            Order OrderEntity = orderDto.ToOrderEntity();
            _repository.OrderReposatory.Add(OrderEntity);
            _repository.SaveChanges();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto Get(string Name)
        {
            throw new NotImplementedException();
        }

        public List<OrderDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDto DTO)
        {
            throw new NotImplementedException();
        }
    }
}
