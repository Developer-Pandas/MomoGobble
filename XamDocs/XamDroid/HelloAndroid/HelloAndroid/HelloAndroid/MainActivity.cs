using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace HelloAndroid
{
    //MainLauncher=true meaning thisis the first activity triggered when app launches try making it false and see app crashing :P
    //Label is the title on the toolbar and name of the app as well because(mainlauncher)
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //This is where activity starts.
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            //Activity is attached to its layout
            SetContentView(Resource.Layout.activity_main);


            //Instance of Toolbar in toolbar variable
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Instance of FAB in fab variable   |Finding element by ID  |<Type of element>      |id of the element       
            FloatingActionButton fab =           FindViewById           <FloatingActionButton>  (Resource.Id.fab);

            //Attaching click event to fab
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //Adding menu options to the toolbar "Settings"
            //find menu.xml in resources folder, try to edit it. add more menu options and take action
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //this is the id of the menu item assigned to it. find this id parameter in menu.xml 
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                Toast.MakeText(this, "I am settings", ToastLength.Short).Show();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        //This is triggered on click of fab button
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            Toast.MakeText(this, "Replace with your own action", ToastLength.Short).Show();
        }
	}
}



//Okay, head over to the Quick Start, read the complete article, then read it again while following the instructions. GO Go Go!