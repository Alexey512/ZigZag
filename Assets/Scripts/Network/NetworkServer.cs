using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Network
{
	public class NetworkServer : MonoBehaviour
	{
		public int port = 8000;

		private HostTopology topology;
		private ConnectionConfig config;
		private int connectionId;
		private int hostId;

		void Start()
		{
			NetworkTransport.Init();
			config = new ConnectionConfig();
			config.AddChannel(QosType.ReliableSequenced);
			topology = new HostTopology(config, 10);
			hostId = NetworkTransport.AddHost(topology, port);
			Debug.Log("Server started on port" + port + " with id of " + hostId);
		}

		void Update()
		{
			int recHostId;
			int recConnectionId;
			int recChannelId;
			byte[] recBuffer = new byte[1024];
			int bufferSize = 1024;
			int dataSize;
			byte error;
			NetworkEventType networkEvent = NetworkTransport.Receive(out recHostId, out recConnectionId, out recChannelId,
				recBuffer, bufferSize, out dataSize, out error);

			NetworkError networkError = (NetworkError) error;
			if (networkError != NetworkError.Ok)
			{
				Debug.LogError(string.Format(
					"Error recieving event: {0} with recHostId: {1}, recConnectionId: {2}, recChannelId: {3}", networkError, recHostId,
					recConnectionId, recChannelId));
			}

			switch (networkEvent)
			{
				case NetworkEventType.Nothing:
					break;
				case NetworkEventType.ConnectEvent:
					Debug.Log(string.Format(
						"incoming connection event received with connectionId: {0}, recHostId: {1}, recChannelId: {2}", recConnectionId,
						recHostId, recChannelId));
					break;
				case NetworkEventType.DataEvent:
					Stream stream = new MemoryStream(recBuffer);
					BinaryFormatter formatter = new BinaryFormatter();
					string message = formatter.Deserialize(stream) as string;
					Debug.Log("incoming message event received: " + message);
					break;
				case NetworkEventType.DisconnectEvent:
					Debug.Log("remote client " + recConnectionId + " disconnected");
					break;
			}
		}
	}
}