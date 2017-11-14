using NUnit.Framework;
using System;
using static Week12SampleApp.Models.WeatherItemModel;
using Week12SampleApp.ViewModels;
using Prism.Navigation;
using Moq;

namespace Week12SampleApp.UnitTests
{
    [TestFixture()]
    public class MainPageViewModelTests
    {
        MainPageViewModel mainPageViewModel;

        Mock<INavigationService> navigationServiceMock;

        [SetUp]
        public void Init()
        {
            navigationServiceMock = new Mock<INavigationService>();
            mainPageViewModel = new MainPageViewModel(navigationServiceMock.Object);
        }

        [Test]
        public void TestRemoveWeatherItemCommandRemovesWeatherItemFromCollection()
        {
            var weatherItemToDelete = new WeatherItem();
            weatherItemToDelete.Name = "San Marcos";
            mainPageViewModel.WeatherCollection.Add(weatherItemToDelete);

            mainPageViewModel.RemoveWeatherItemCommand.Execute(weatherItemToDelete);

            CollectionAssert.DoesNotContain(mainPageViewModel.WeatherCollection, 
                                            weatherItemToDelete);
        }

        [Test]
        public void TestOnNavigatedToPopulatesTitle()
        {
            mainPageViewModel.Title = string.Empty;
            mainPageViewModel.OnNavigatedTo(null);
            Assert.AreEqual("Week 12 Sample App", mainPageViewModel.Title);
        }
    }
}
