using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMaster : Photon.PunBehaviour
{

    public string leaderSymbol = "Leader: ";
    public List<GameObject> playerNames = new List<GameObject>(4);
    public int maxNrPlayers = 4;
    private void Awake()
    {
        for (int i = 0; i < maxNrPlayers && i < PhotonNetwork.playerList.Length; i++)
        {
            if (PhotonNetwork.playerList[i].IsMasterClient || PhotonNetwork.playerList.Length == 1)
            {
                playerNames[i].GetComponent<Text>().text = leaderSymbol + PhotonNetwork.playerList[i].NickName;
            }
            else
            {
                playerNames[i].GetComponent<Text>().text = PhotonNetwork.playerList[i].NickName;
            }
        }
    }
    private void OnPhotonPlayerConnected()
    {
        for (int i = 0; i < maxNrPlayers && i < PhotonNetwork.playerList.Length; i++)
        {
            if (PhotonNetwork.playerList[i].IsMasterClient || PhotonNetwork.playerList.Length == 1)
            {
                playerNames[i].GetComponent<Text>().text = leaderSymbol + PhotonNetwork.playerList[i].NickName;
            }
            else
            {
                playerNames[i].GetComponent<Text>().text = PhotonNetwork.playerList[i].NickName;
            }
        }
    }

    private void OnPhotonPlayerDisconnected()
    {
        for (int i = 0; i < maxNrPlayers; i++)
        {
            if (i >= PhotonNetwork.playerList.Length)
            {
                playerNames[i].GetComponent<Text>().text = "";
                continue;
            }

            if (PhotonNetwork.playerList[i].IsMasterClient || PhotonNetwork.playerList.Length == 1)
            {
                playerNames[i].GetComponent<Text>().text = leaderSymbol + PhotonNetwork.playerList[i].NickName;
            }
            else
            {
                playerNames[i].GetComponent<Text>().text = PhotonNetwork.playerList[i].NickName;
            }
        }
    }

    private void OnMasterClientSwitched()
    {
        if (PhotonNetwork.isMasterClient || PhotonNetwork.playerList.Length == 1)
        {

        }
    }

}
