using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
public class GameManager : NetworkBehaviour
{
    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static GameManager instance;

    public const string playerIdPrefix = "Player_";

    private bool isAdminHere = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (!isAdminHere)
        {
            foreach (Player player in GetAllPlayers())
            {
                if (player.username == "Admin")
                {
                    isAdminHere = true;
                    /*if (StartGame() != null)
                        StartCoroutine(StartGame());*/
                    return;
                }
            }
        }
    }

    public static void RegisterPlayer(string netID, Player player)
    {
        string playerId = playerIdPrefix + netID;
        players.Add(playerId, player);
        player.transform.name = playerId;
    }

    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }

    public static Player GetPlayer(string playerId)
    {
        return players[playerId];
    }

    public static Player[] GetAllPlayers()
    {
        return players.Values.ToArray();
    }
}
