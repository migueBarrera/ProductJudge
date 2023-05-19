using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Platforms.Android;
using Plugin.Firebase.Bundled.Shared;
//using Plugin.Firebase.Auth;
//using Plugin.Firebase.Auth.Facebook;
//using Plugin.Firebase.CloudMessaging;
//using Plugin.Firebase.DynamicLinks;
//using Plugin.Firebase.Functions;
//using Plugin.Firebase.RemoteConfig;
//using Plugin.Firebase.Bundled.Shared;
//#if IOS
//using Plugin.Firebase.Bundled.Platforms.iOS;
//using Playground.Platforms.iOS.Services.UserInteraction;
//#else
//using Plugin.Firebase.Bundled.Platforms.Android;
//using Playground.Platforms.Android.Services.UserInteraction;
//#endif
//using Plugin.Firebase.Storage;
using ProductJudge.Mobile.Features;

namespace ProductJudge.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterFirebaseServices()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<HomePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((_, __) => {
                CrossFirebase.Initialize();
                return false;
            }));
#else
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(
            isAnalyticsEnabled: true,
            isAuthEnabled: true,
            isCloudMessagingEnabled: false,
            isDynamicLinksEnabled: false,
            isFirestoreEnabled: false,
            isFunctionsEnabled: false,
            isRemoteConfigEnabled: false,
            isStorageEnabled: false,
            googleRequestIdToken: "537235599720-723cgj10dtm47b4ilvuodtp206g0q0fg.apps.googleusercontent.com");
    }
}
