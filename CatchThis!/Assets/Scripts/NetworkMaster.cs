using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMaster : MonoBehaviour
{

    public string leaderSymbol = "Leader: ";
    private void OnPlayerEnteredRoom()
    {

    }

    private void OnJoinedRoom()
    {
        foreach (PhotonPlayer player in PhotonNetwork.playerList)
        {
            Debug.Log(player.NickName);
        }
    }
}
