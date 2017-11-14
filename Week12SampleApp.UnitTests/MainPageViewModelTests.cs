using NUnit.Framework;
using System;
using static Week12SampleApp.Models.WeatherItemModel;
using Week12SampleApp.ViewModels;

namespace Week12SampleApp.UnitTests
{
    [TestFixture()]
    public class MainPageViewModelTests
    {
        MainPageViewModel mainPageViewModel;

        [SetUp]
        public void Init()
        {
            mainPageViewModel = new MainPageViewModel();
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
