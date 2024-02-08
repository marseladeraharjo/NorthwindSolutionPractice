using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindWebMvc.Basic.Controllers;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Repository;

namespace NorthwindXUnit.Basic
{
    public class CategoryControllerTest
    {
        [Fact]
        public async void Index_ReturnViewResult_WithCategoryList()
        {
            // Arrange
            var mockRepo = new Mock<IRepositoryBase<Category>>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(new Category[]
                {
                    new Category { Id = 1, CategoryName="TV Samsung", Description="Digital"},
                    new Category { Id = 2, CategoryName="Kulkas Panasonic", Description="Kulkas"}
                }.ToList());

            var controller = new CategoriesController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.Model);
            Assert.Equal(2, model.Count());

        }
    }
}