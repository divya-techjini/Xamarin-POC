using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Gallery
{
	[Activity(Label = "Gallery", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			ImageView imageView =
					FindViewById<ImageView>(Resource.Id.myImageView1);
			button.Click += delegate
			{
				var imageIntent = new Intent();

				imageIntent.SetType("image/*");
				imageIntent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(
					Intent.CreateChooser(imageIntent, "Select photo"), 0);
			};
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok)
			{
				var imageView =
					FindViewById<ImageView>(Resource.Id.myImageView1);
				imageView.SetImageURI(data.Data);
			}
		}
	}
}

