using System.Collections.Generic;
using Android.Content;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;


namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView SubmitFeedback = FindViewById<TextView>(Resource.Id.SubmitFeedback);
            Button SubmitButton = FindViewById<Button>(Resource.Id.SubmitButton);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.FeedbackHistoryButton);
            string translatedNumber = string.Empty;
            SubmitButton.Click += (sender, e) =>
            {
               
                translatedNumber = Feedback.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    SubmitFeedback.Text = string.Empty;
                }
                else
                {
                    SubmitFeedback.Text = translatedNumber;
                }
            };
            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(History));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
    }
}