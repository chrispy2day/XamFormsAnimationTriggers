using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PropertyChanged;

namespace XamFormsAnimationTriggers.ViewModels
{
    // Note that ImplementPropertyChanging is not supported in this PCL Profile, so can't use that to trigger animation
    [ImplementPropertyChanged]
    public class AnimateViewModel
    {
        public AnimateViewModel()
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
        private AnimationApproach _curApproach;
        public AnimationApproach CurrentApproach 
        { 
            get { return _curApproach; }
            private set
            {
                if (CurrentApproach == AnimationApproach.PropertyChanging)
                    Animation(); // note that the approach will be updated before the animation is complete here - can't await, same with raising an event
                _curApproach = value; 
            }
        }
        public string Approach => Enum.GetName(typeof(AnimationApproach), CurrentApproach);
        public ICommand Animate { get; private set; }
        public Func<Task> Animation { get; set; }
    }
}