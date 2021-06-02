using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHealth : MonoBehaviour
{
    private string symbol;
    public GameObject localPlayer;
    void Start()
    {
        symbol = gameObject.GetComponent<UnityEngine.UI.Text>().text;
    }
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = symbol + localPlayer.GetComponent<PlayerMovement>().health;
    }
}
