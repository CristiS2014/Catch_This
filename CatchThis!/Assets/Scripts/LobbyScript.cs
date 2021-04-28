using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public Text player1, player2, player3, player4;
    public GameObject button1, button2;
    GameObject main;
    string level;

    void Start()
    {
        if (MainScript.leader)
        {
            player1.text += " " + MainScript.nickname;
            button1.SetActive(true);
            button2.SetActive(true);
        }
        else if (!MainScript.leader && player2.text == "")
            player2.text = MainScript.nickname;
        else if (!MainScript.leader && player3.text == "")
            player3.text = MainScript.nickname;
        else if (!MainScript.leader && player4.text == "")
            player4.text = MainScript.nickname;
        main = GameObject.Find("MainLobby");
        level = "Level 1";
        main.transform.Find(level).gameObject.SetActive(true);
    }

    void Update()
    {
    }
    public void selectCharacter1()
    {
        MainScript.character = "Character 1";
    }
    public void selectCharacter2()
    {
        MainScript.character = "Character 2";
    }
    public void selectCharacter3()
    {
        MainScript.character = "Character 3";
    }
    public void selectCharacter4()
    {
        MainScript.character = "Character 4";
    }
    public void selectLevel1()
    {
        main.transform.Find(level).gameObject.SetActive(false);
        level = "Level 1";
        main.transform.Find(level).gameObject.SetActive(true);
    }
    public void selectLevel2()
    {
        main.transform.Find(level).gameObject.SetActive(false);
        level = "Level 2";
        main.transform.Find(level).gameObject.SetActive(true);
    }
    public void selectLevel3()
    {
        main.transform.Find(level).gameObject.SetActive(false);
        level = "Level 3";
        main.transform.Find(level).gameObject.SetActive(true);
    }
    public void selectLevel4()
    {
        main.transform.Find(level).gameObject.SetActive(false);
        level = "Level 4";
        main.transform.Find(level).gameObject.SetActive(true);
    }
    public void play()
    {
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Lobby");
    }
    public void exitLobby()
    {
        GameObject.Find("EventSystemLobby").SetActive(false);
        GameObject.Find("Main").transform.Find("CanvasUI").gameObject.SetActive(true);
        GameObject.Find("Main").transform.Find("EventSystemUI").gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Lobby");
    }
}
