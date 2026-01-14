using Godot;
using Nakama;
using System;
using System.Threading.Tasks;

public partial class NetworkManager : Node
{
    public static NetworkManager Instance { get; private set; }

    // Nakama settings
    private const string Scheme = "http";
    private const string Host = "localhost";
    private const int Port = 7350;
    private const string ServerKey = "defaultkey";

    public IClient Client { get; private set; }
    public ISession Session { get; private set; }
    public ISocket Socket { get; private set; }

    public override void _Ready()
    {
        Instance = this;
        InitializeNakama();
    }

    private async void InitializeNakama()
    {
        Client = new Client(Scheme, Host, Port, ServerKey);

        // Use a random GUID for device ID to allow multiple instances on the same machine
        // In production, you would save this to a file.
        string deviceId = System.Guid.NewGuid().ToString();

        try
        {
            Session = await Client.AuthenticateDeviceAsync(deviceId);
            GD.Print($"Authenticated as {Session.Username} (ID: {Session.UserId})");

            Socket = Client.NewSocket();
            await Socket.ConnectAsync(Session, true);
            GD.Print("Socket connected.");
        }
        catch (Exception e)
        {
            GD.PrintErr($"Nakama connection failed: {e.Message}");
        }
    }
}
