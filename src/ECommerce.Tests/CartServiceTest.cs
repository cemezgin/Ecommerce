using Microsoft.AspNetCore.Mvc;
using ECommerce.Controllers;
using ECommerce.Services;
using ECommerce.Models;
using ECommerce.Data;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;

public class CartServiceTest
{
    CartService _service;
    public CartServiceTest()
    {
        var itemContext = new Mock<ICartItemContext>();
        _service = new CartService(itemContext.Object);
    }

    [Fact]
    public void Check_ServiceInstanceExist()
    {
        //Assert
        Assert.NotNull(_service);
    }
    
}