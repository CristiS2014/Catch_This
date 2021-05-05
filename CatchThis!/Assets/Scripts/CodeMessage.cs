using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeMessage : MonoBehaviour
{
    public Text readName;
    public GameObject info;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public List<GameObject> playerNames;
    public string leaderSymbol = "Leader: ";
    public void showMessage()
    {
        /*
        if (readName.text != "SALUT")
            info.SetActive(true);
        else
        {
            SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
            GameObject.Find("CanvasUI").SetActive(false);
            GameObject.Find("EventSystemUI").SetActive(false);
            MainScript.leader = false;
        }
        */
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinRoom(readName.text.ToUpper());
    }

    private void OnJoinedRoom()
    {
        Debug.Log("Joined room " + PhotonNetwork.room.Name);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
        GameObject.Find("CanvasUI").SetActive(false);
        GameObject.Find("EventSystemUI").SetActive(false);
        MainScript.leader = false;

    }

    private void OnPhotonJoinRoomFailed()
    {
        Debug.Log("Join room failed");
        info.SetActive(true);
    }
}
