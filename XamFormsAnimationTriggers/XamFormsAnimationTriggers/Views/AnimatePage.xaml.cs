using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamFormsAnimationTriggers.ViewModels;
using XamFormsAnimationTriggersShared;

namespace XamFormsAnimationTriggers.Views
{
    public partial class AnimatePage : ContentPage
    {
        public AnimatePage()
        {
            InitializeComponent();

            // using PCL
            //var vm = new AnimateViewModel();
            //vm.Animation = MoveBox;

            // using Shared Project
            var vm = new SharedAnimationViewModel();
            vm.Animation = MoveBox;

            BindingContext = vm;
        }

        private async Task MoveBox()
        {
            box.TranslateTo(100, 100, 250, Easing.SinOut);
            await box.RotateTo(90);
            box.TranslateTo(-100, -100, 250, Easing.SinInOut);
            await box.RotateTo(180);
            box.TranslateTo(0, 0, 250, Easing.SinInOut);
            await box.RotateTo(0);
        }
    }
}
