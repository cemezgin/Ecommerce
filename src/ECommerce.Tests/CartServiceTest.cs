using Microsoft.AspNetCore.Mvc;
using ECommerce.Controllers;
using ECommerce.Services;
using ECommerce.Models;
using ECommerce.Repository;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;

public class CartServiceTest
{
    CartService _service;
    public CartServiceTest()
    {
        var itemRepository = new Mock<ICartItemRepository>();
        _service = new CartService(itemRepository.Object);
    }

    [Fact]
    public void Check_ServiceInstanceExist()
    {
        //Assert
        Assert.NotNull(_service);
    }
    
}