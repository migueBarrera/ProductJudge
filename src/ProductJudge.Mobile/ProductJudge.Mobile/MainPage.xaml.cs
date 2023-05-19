//using Plugin.Firebase.Auth;

using Microsoft.Extensions.Logging;
using Plugin.Firebase.Auth;
using ProductJudge.Mobile.Features;

namespace ProductJudge.Mobile;

public partial class MainPage : ContentPage
{
    private readonly IFirebaseAuth _firebaseAuth;
    private readonly ILogger<MainPage> _logger;
    private readonly IServiceProvider serviceProvider;

    public MainPage(IFirebaseAuth firebaseAuth, ILogger<MainPage> logger, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _firebaseAuth = firebaseAuth;
        _logger = logger;
        this.serviceProvider = serviceProvider;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
        await SignIngGoogle();
	}

    private async Task SignIngGoogle()
    {
        try
        {
            
            var firebaseUser = await _firebaseAuth.SignInWithGoogleAsync();
            if (firebaseUser != null)
            {
                var homePage = serviceProvider.GetService<HomePage>();
                await Shell.Current.Navigation.PushAsync(homePage);
            }
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("Error", ex.Message, "Cancel");
            _logger.LogError(ex.Message);
        }
    }
}

