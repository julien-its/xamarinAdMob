
using Android.Content;
using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(JitsAdMob.Controls.AdControlView), typeof(JitsAdMob.Droid.PlatformSpecific.AdViewRenderer))]
namespace JitsAdMob.Droid.PlatformSpecific
{
    public class AdViewRenderer : ViewRenderer<Controls.AdControlView, AdView>
    {
        string adUnitId = string.Empty;
        AdSize adSize = AdSize.Banner;
        AdView adView;

        Context _context;

        public AdViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        AdView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;

            // This is a string in the Resources/values/strings.xml that I added or you can modify it here. This comes from admob and contains a / in it
            adUnitId = "ca-app-pub-3940256099942544/6300978111"; // Test banner unit
            adView = new AdView(_context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;

            AdRequest adRequest = new AdRequest
                                    .Builder()
                                    .Build();

            adView.LoadAd(adRequest);

            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Controls.AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}