using PXLIDCardV2.ui.Models;
using PXLIDCardV2.ui.Services;
using PXLIDCardV2.ui.ViewModels.OptViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PXLIDCardV2.ui.ViewModels
{
    public class OptionsViewModel : ViewModelBase
    {


        private readonly INavigationService _navigationService;
        public OptionsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Options = new List<Option>
            {
                new Option
                {
                    Name = "Login"
                },
                new Option
                {
                    Name = "QR-Code"
                },
                new Option
                {
                    Name = "My Evaluations"
                },
                new Option
                {
                    Name = "Logout"
                }
            };
        }

        public IList<Option> Options { get; set; }
        public Command OptionSelectedCommand => new Command<Option>(OnOptionSelected);

        public async void OnOptionSelected(Option option)
        {
            switch (option.Name) {
                case "Login":
                    await _navigationService.NavigateToAsync<OptLoginViewModel>();
                    break;

                case "QR-Code":
                    await _navigationService.NavigateToAsync<OptQRCodeViewModel>();
                    break;

                case "My Evaluations":
                    await _navigationService.NavigateToAsync<OptEvaluationsViewModel>();
                    break;
                case "Logout":
                    await _navigationService.NavigateToAsync<OptWelcomeViewModel>();
                    break;


            }
        }
    }
}
