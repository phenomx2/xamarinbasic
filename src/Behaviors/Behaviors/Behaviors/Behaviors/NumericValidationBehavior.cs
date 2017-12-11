using Xamarin.Forms;

namespace Behaviors.Behaviors
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            double result; 
            var isValid = double.TryParse(e.NewTextValue, out result);
            ((Entry) sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}