using MauiApp1.Features.Chat;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;
using Plugin.BLE.Abstractions.Exceptions;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private ChatServices chatServices;
        private IBluetoothLE ble;
        private IAdapter adapter;

        private ObservableCollection<IDevice> devices = new ObservableCollection<IDevice>();

        private ObservableCollection<string> messages = new ObservableCollection<string>();

        public MainPage(ChatServices chatServices)
        {
            InitializeComponent();

            this.chatServices = chatServices;

            
            chatServices.OnMessageReceived += chatServices_OnMessageReceived;
        }

        private void chatServices_OnMessageReceived(object sender, ChatMessage e)
        {
            messages.Add(e.Message);
            //messages.Add(new ChatMessageViewModel { Name = e.Name, Message = e.Message, IsMine = _messages.Count % 2 == 0 });
        }

        public Command SendMessageCommand { get; set; }

        async void ExecuteSendMessageCommand()
        {
            await chatServices.Connect();
            IsBusy = true;
            await chatServices.Send(new ChatMessage { Name = "test", Message = "Test" }, "RoomTest" );
            IsBusy = false;
        }

        async void ExecuteJoinRoomCommand()
        {
            IsBusy = true;
            await chatServices.JoinRoom("RoomTest");
            IsBusy = false;
        }

        private void SendTest_Clicked(object sender, EventArgs e)
        {
            ExecuteSendMessageCommand();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            ExecuteJoinRoomCommand();
        }
    }

}
