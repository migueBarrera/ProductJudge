using Microsoft.AspNet.SignalR.Client;

namespace MauiApp1.Features.Chat;

public class ChatServices
{
    private readonly HubConnection _connection;
    private readonly IHubProxy _proxy;

    public event EventHandler<ChatMessage> OnMessageReceived;

    public ChatServices()
    {
        _connection = new HubConnection("http://localhost:5150/");
        _proxy = _connection.CreateHubProxy("ChatHub");
    }

    #region IChatServices implementation

    public async Task Connect()
    {
        await _connection.Start();

        _proxy.On("GetMessage", (string name, string message) => OnMessageReceived(this, new ChatMessage
        {
            Name = name,
            Message = message
        }));
    }

    public async Task Send(ChatMessage message, string roomName)
    {
        _proxy.Invoke("SendMessage", message.Name, message.Message, roomName);
    }

    public async Task JoinRoom(string roomName)
    {
        _proxy.Invoke("JoinRoom", roomName);
    }

    #endregion
}
