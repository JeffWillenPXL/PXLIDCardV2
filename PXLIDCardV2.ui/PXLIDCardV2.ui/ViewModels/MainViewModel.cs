using PXLIDCardV2.ui.Services;
using PXLIDCardV2.ui.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace PXLIDCardV2.ui.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public OptionsViewModel OptionsViewModel { get; set; }
        public MainViewModel()
        {
            OptionsViewModel = new OptionsViewModel(AppContainer.Resolve<INavigationService>());
        }
    }
}
