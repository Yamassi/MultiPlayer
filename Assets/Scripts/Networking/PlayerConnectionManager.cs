using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerConnectionManager : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef _playerPrefab;
    
    private readonly Dictionary<PlayerRef,NetworkObject> _players = new ();
    
    public void PlayerJoined(PlayerRef player)
    {
        if(!Runner.IsServer) return;
        
        NetworkObject playerOjbect = Runner.Spawn(_playerPrefab,Vector3.zero, Quaternion.identity,player);
        _players.Add(player,playerOjbect);
    }

    public void PlayerLeft(PlayerRef player)
    {
        if(!Runner.IsServer) return;

        if (_players.Remove(player, out var playerOjbect)) 
            Runner.Despawn(playerOjbect);
    }
}
