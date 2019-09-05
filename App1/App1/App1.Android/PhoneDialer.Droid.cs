using Android.Content;
using System.Linq;
using System.Threading.Tasks;
using Android.Telephony;
using Xamarin.Forms;
using App1.Droid;

using Uri = Android.Net.Uri;

//export; This allows us to find this using the dependency service later on.
[assembly: Dependency(typeof(PhoneDialer))]

namespace App1.Droid
{
    public class PhoneDialer : IDialer
    {
    	/// <summary>
    	/// Dial the phone
    	/// </summary>
		public Task<bool> DialAsync(string number)
		{
			var context = Forms.Context;
    	    if (context != null)
    	    {
                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + number));

                if (IsIntentAvailable(context, intent))
                {
                    context.StartActivity(intent);
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
		}

        /// <summary>
        /// Checks if an intent can be handled.
        /// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;
            
			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;
            
			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
        }
    }
}
