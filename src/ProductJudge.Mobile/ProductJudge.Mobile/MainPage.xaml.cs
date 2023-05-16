//using Plugin.Firebase.Auth;

using Microsoft.Extensions.Logging;
using Plugin.Firebase.Auth;

namespace ProductJudge.Mobile;

public partial class MainPage : ContentPage
{
    private readonly IFirebaseAuth _firebaseAuth;
    private readonly ILogger<MainPage> _logger;

    public MainPage(IFirebaseAuth firebaseAuth, ILogger<MainPage> logger)
    {
        InitializeComponent();
        _firebaseAuth = firebaseAuth;
        _logger = logger;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
	{
        await SignIngGoogle();
	}

    private async Task SignIngGoogle()
    {
        try
        {
            var v = _firebaseAuth.CurrentUser;
            if (v != null)
            {

            }
            var firebaseUser = await _firebaseAuth.SignInWithGoogleAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}

