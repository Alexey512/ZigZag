using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using IngameDebugConsole;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Network
{
	public class NetworkClient : MonoBehaviour
	{
		public string host = "127.0.0.1";
		public int port = 8000;

		private int hostId;
		private int connectionId;
		private ConnectionConfig config;
		private HostTopology hostTopology;
		private byte channelId;


		private static NetworkClient _instance;
		void Awake()
		{
			if (_instance == null)
				_instance = this;
		}

		void Start()
		{
			NetworkTransport.Init();

			Connect();
		}

		public void Connect()
		{
			byte error;
			config = new ConnectionConfig();
			channelId = config.AddChannel(QosType.ReliableSequenced);
			hostTopology = new HostTopology(config, 1);
			hostId = NetworkTransport.AddHost(hostTopology, port);

			connectionId = NetworkTransport.Connect(hostId, host, port, 0, out error);
			NetworkError networkError = (NetworkError) error;
			if (networkError != NetworkError.Ok)
			{
				Debug.LogError($"Unable to connect to {host}:{port}, Error: {networkError}");
			}
			else
			{
				Debug.Log(string.Format("Connected to {0}:{1} with hostId: {2}, connectionId: {3}, channelId: {4},", host, port,
					hostId, connectionId, channelId));
			}
		}

		[ConsoleMethod("test_msg", "Test message")]
		public static void TestMessage()
		{
			if (_instance == null)
				return;
			_instance.SendSocketMessage();
		}

		public void SendSocketMessage()
		{
			byte error;
			byte[] buffer = new byte[1024];
			Stream stream = new MemoryStream(buffer);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, "Hello");
			int bufferSize = 1024;

			NetworkTransport.Send(hostId, connectionId, channelId, buffer, bufferSize, out error);
			NetworkError networkError = (NetworkError) error;
			if (networkError != NetworkError.Ok)
			{
				Debug.LogError(string.Format("Error: {0}, hostId: {1}, connectionId: {2}, channelId: {3}", networkError, hostId,
					connectionId, channelId));
			}
			else
			{
				Debug.Log("Message sent!");
			}
		}
	}
}