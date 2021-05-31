using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHealth : MonoBehaviour
{
    private string symbol;
    void Start()
    {
       symbol =  gameObject.GetComponent<UnityEngine.UI.Text>().text;
    }
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = symbol + PlayerMovement.health_txt;
    }
}
