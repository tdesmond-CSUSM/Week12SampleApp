using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using static Week12SampleApp.Models.WeatherItemModel;
using Week12SampleApp.Models;

namespace Week12SampleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand<WeatherItem> RemoveWeatherItemCommand { get; set;  }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RemoveWeatherItemCommand = new DelegateCommand<WeatherItem>(RemoveWeatherItem);

        }

        private void RemoveWeatherItem(WeatherItem itemToDelete)
        {
            WeatherCollection.Remove(itemToDelete);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Week 12 Sample App";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}

