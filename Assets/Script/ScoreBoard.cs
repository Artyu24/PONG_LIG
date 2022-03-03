using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private GameObject playerScoreboardItem;

    [SerializeField] private Transform playerScoreboardList;

    private List<Player> listPlayerPrint = new List<Player>();

    private bool isActive = false;

    private void OnEnable()
    {
        isActive = true;

        Player[] dataPlayers = GameManager.GetAllPlayers();

        while (listPlayerPrint.Count < dataPlayers.Length)
        {
            Player playerChoose = null;
            int bestScore = 0;

            foreach (Player player in dataPlayers)
            {
                /*if (!listPlayerPrint.Contains(player) && bestScore <= player.GetActualScore)
                {
                    bestScore = player.GetActualScore;
                    playerChoose = player;
                }*/
            }
            GameObject itemGO = Instantiate(playerScoreboardItem, playerScoreboardList);
            listPlayerPrint.Add(playerChoose);
            PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();
            if (item != null)
            {
                item.Setup(playerChoose);
            }
        }
    }

    private void Update()
    {
        if (isActive)
        {
            
            foreach (Transform child in playerScoreboardList)
            {
                Destroy(child.gameObject);
            }

            listPlayerPrint.Clear();

            Player[] dataPlayers = GameManager.GetAllPlayers();

            while (listPlayerPrint.Count < dataPlayers.Length)
            {
                Player playerChoose = null;
                int bestScore = 0;

                foreach (Player player in dataPlayers)
                {
                    /*if (!listPlayerPrint.Contains(player) && bestScore <= player.GetActualScore)
                    {
                        bestScore = player.GetActualScore;
                        playerChoose = player;
                    }*/
                }
                GameObject itemGO = Instantiate(playerScoreboardItem, playerScoreboardList);
                listPlayerPrint.Add(playerChoose);
                PlayerScoreboardItem item = itemGO.GetComponent<PlayerScoreboardItem>();
                if (item != null)
                {
                    item.Setup(playerChoose);
                }
            }
        }

    }

    private void OnDisable()
    {
        isActive = false;

        foreach (Transform child in playerScoreboardList)
        {
            Destroy(child.gameObject);
        }

        listPlayerPrint.Clear();
    }
}
