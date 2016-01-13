using System;
using Xamarin.Forms;
using PropertyChanging;
using PropertyChanged;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace XamFormsAnimationTriggersShared
{
    [ImplementPropertyChanged]
    public class SharedAnimationViewModel : INotifyPropertyChanging
    {
        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;

        public SharedAnimationViewModel()
        {
            Animate = new Command(async (_) => await PerformAnimationAsync());
            CurrentApproach = AnimationApproach.AsyncFunc;
        }

        public enum AnimationApproach { AsyncFunc, PropertyChanging }

        private async Task PerformAnimationAsync()
        {
            // perform the animation
            if (CurrentApproach == AnimationApproach.AsyncFunc)
            {
                await Animation();
            }

            // update the animation approach
            CurrentApproach = (CurrentApproach == AnimationApproach.AsyncFunc) ? AnimationApproach.PropertyChanging : AnimationApproach.AsyncFunc;
        }

        public string Title { get; set; } = "Animation Approaches";
        public AnimationApproach CurrentApproach { get; private set; }
        public string Approach => Enum.GetName(typeof(AnimationApproach), CurrentApproach);
        public ICommand Animate { get; private set; }
        public Func<Task> Animation { get; set; }
    }
}

