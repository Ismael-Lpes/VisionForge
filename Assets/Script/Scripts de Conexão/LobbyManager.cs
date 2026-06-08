using Fusion;
using UnityEngine;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviour
{
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        foreach (var session in sessionList)
        {
            Debug.Log($"Sala: {session.Name} | Jogadores: {session.PlayerCount}/{session.MaxPlayers}");
        }
    }
}