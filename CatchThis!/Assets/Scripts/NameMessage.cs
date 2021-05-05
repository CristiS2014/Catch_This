using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameMessage : MonoBehaviour
{
    public Text info;
    public Text readName;

    const string roomNameChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const int roomNameLength = 4;
    public void showMessage()
    {
        info.gameObject.SetActive(true);
        info.text = "Your username is now " + readName.text;
        MainScript.nickname = readName.text;
    }
    public void setLeader()
    {
        MainScript.leader = true;
        GameObject.Find("CanvasUI").SetActive(false);
        GameObject.Find("EventSystemUI").SetActive(false);
        SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Additive);

    }

    public void CreateGame()
    {
        string roomName = "";
        for (int i = 0; i < roomNameLength; i++)
        {
            roomName += roomNameChars[Random.Range(0, roomNameChars.Length - 1)];
        }
        Debug.Log("Room Name " + roomName);
        PhotonNetwork.CreateRoom(roomName, new RoomOptions() { maxPlayers = 4 }, null);
    }
}
