using MobileDeliveryMVVM.Command;
using System;
using Xamarin.Forms;

namespace MobileDeliveryUniversal.Behaviors
{
    public class TruckContentPageBehavior : Behavior<ContentPage>
    {
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create("Command", typeof(ICommand), typeof(TruckContentPageBehavior), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Appearing += OnListViewItemAppearing;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Appearing -= OnListViewItemAppearing;
        }
        public delegate void EventHandler(object sender, EventArgs e);
        private void OnListViewItemAppearing(object sender, EventArgs e)
        {
            ItemVisibilityEventArgs evargs = (ItemVisibilityEventArgs)e;

            if (Command == null)
                return;

            if (Command.CanExecute(evargs.Item))
                Command.Execute(evargs.Item);

        }
    }
}
