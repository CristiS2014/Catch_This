using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu, Logo;
    float intro_countdown;

    [SerializeField] private string versionName = "0.1";

    void Start()
    {
        intro_countdown = 2f;
        Logo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (intro_countdown <= 0)
        {
            PhotonNetwork.ConnectUsingSettings(versionName);
            Logo.SetActive(false);
            Menu.SetActive(true);
            gameObject.GetComponent<IntroScript>().enabled = false;
        }
        else
            intro_countdown -= Time.deltaTime;
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        PhotonNetwork.playerName = "";
        Debug.Log("Connected to master");
    }

    private void OnDisconnected()
    {
        // TODO -> daca mesaj eroare daca nu ma pot conecta la sv (ex nu am net)
    }
}
