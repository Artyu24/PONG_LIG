using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] 
    private Behaviour[] componentsToDisable;

    [SerializeField] 
    private GameObject playerCameraPrefab;
    [SerializeField] 
    private GameObject playerUIPrefab;
    private GameObject playerUIInstance;
    public GameObject GetPlayerUIInstance { get { return playerUIInstance; } }

    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            //CameraPrefab
            Instantiate(playerCameraPrefab);

            // Cr�ation UI joueur local
            playerUIInstance = Instantiate(playerUIPrefab);

            // Config UI
            PlayerUI ui = playerUIInstance.GetComponent<PlayerUI>();
            ui.SetDataPlayer(GetComponent<Player>());

            CmdSetUsername(transform.name, UserAccountManager.LoggedInUsername);
        }
    }

    [Command]
    private void CmdSetUsername(string playerID, string username)
    {
        Player player = GameManager.GetPlayer(playerID);
        if (player != null)
        {
            player.username = username;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        RegisterPlayerAndSetUsername();
    }

    /*
    // Utilis� dans le cas o� le build est uniquement un serveur
    public override void OnStartServer()
    {
        base.OnStartServer();

        RegisterPlayerAndSetUsername();
    }
    */

    private void RegisterPlayerAndSetUsername()
    {
        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();

        GameManager.RegisterPlayer(netId, player);
    }

    private void OnDisable()
    {
        Destroy(playerUIInstance);

        GameManager.UnregisterPlayer(transform.name);
    }
}
