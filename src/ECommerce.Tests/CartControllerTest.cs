using Microsoft.AspNetCore.Mvc;
using ECommerce.Controllers;
using ECommerce.Services;
using ECommerce.Models;
using ECommerce.Data;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
public class CartControllerTest
{
    CartController _controller;

 
    public CartControllerTest()
    {   
        Mock<ICartService> cartService = new Mock<ICartService>();
        Mock<IProductService> productService = new Mock<IProductService>();
        
        var shoppingCart = new Base().GetMockShoppingCart();
        cartService.Setup(x => x.GetShoppingCart()).Returns(shoppingCart);
        _controller = new CartController(productService.Object, cartService.Object);
    }
 
    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        // act
        var result = _controller.GetCartItems();

        // assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsAllItems()
    {
        // Act
        var okResult = _controller.GetCartItems().Result as OkObjectResult;
 
        // Assert
        var items = Assert.IsType<List<ShoppingCart>>(okResult.Value);
        Assert.Equal(1, items.Count);
    }
  
    [Fact]
    public void Add_ValidObjectPassed_ReturnsCreatedResponse()
    {
        // Arrange
        CartItem testItem = new CartItem()
        {
            ProductId = 1,
        };
    
        // Act
        var createdResponse = _controller.PostCartItem(testItem);
    
        // Assert
        Assert.IsType<CreatedAtActionResult>(createdResponse);
    }
}