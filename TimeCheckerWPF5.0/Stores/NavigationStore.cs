﻿using System;
using System.Windows.Input;
using TimeCheckerWPF5._0.ViewModels;

namespace TimeCheckerWPF5._0.Stores
{

    public class NavigationStore
    {

        public ICommand ShowTimeCheckerCommand { get; }
        public ICommand ShowElapsedTimesCommand { get; }

        public NavigationStore()
        {
            ShowTimeCheckerCommand = new NavigationCommandTimeChecker(this);
            ShowElapsedTimesCommand = new NavigationCommandElapsedTimes(this);
        }


        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
