using Microsoft.Extensions.Logging;
using Plugin.Firebase.Auth;

namespace ProductJudge.Mobile.Features;

public partial class HomePage : ContentPage
{
    private readonly IFirebaseAuth _firebaseAuth;
    private readonly ILogger<HomePage> _logger;

    public HomePage(IFirebaseAuth firebaseAuth, ILogger<HomePage> logger)
    {
        InitializeComponent();
        _firebaseAuth = firebaseAuth;
         
        Email.Text = firebaseAuth.CurrentUser?.Email ?? string.Empty;
    }
}