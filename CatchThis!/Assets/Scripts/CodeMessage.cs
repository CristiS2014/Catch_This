using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeMessage : MonoBehaviour
{
    public Text readName;
    public GameObject info;
    public void showMessage()
    {
        if (readName.text != "SALUT")
            info.SetActive(true);
        else
        {
            SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
            GameObject.Find("CanvasUI").SetActive(false);
            GameObject.Find("EventSystemUI").SetActive(false);
            MainScript.leader = false;
        }
    }
}
