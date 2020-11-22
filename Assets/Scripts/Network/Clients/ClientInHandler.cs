﻿using UnityEngine;

// Send request to the server to avoid a server 
// reference in a client side
public class ClientInHandler : MonoBehaviour
{
	[SerializeField] private ClientRequests _clientRequests = null;

	#region Unity Methods
	private void Start()
	{
		if (!_clientRequests)
		{
			Logger.Write($"Client Requests is undefined in {name}", LogType.ERROR);
			return;
		}
	}

	private void OnEnable()
	{
		if (_clientRequests)
		{
			_clientRequests.OnUpdateData += SendRequests;
		}
	}
	private void OnDisable()
	{
		if (_clientRequests)
		{
			_clientRequests.OnUpdateData -= SendRequests;
		}
	}
	#endregion

	private void SendRequests()
	{
		// TODO Keep it
		//if (_clientDatas.IsOwnerByTheClient)
		//{
		Logger.Write($"[{_clientRequests.ClientId}] Send Requests");
		if (!_clientRequests)
			return;

		foreach (var clientRequest in _clientRequests.RequestOut)
		{
			ServerManager.Instance.AddRequest(clientRequest);
		}
		//}
	}
}
