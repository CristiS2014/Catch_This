using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu, Logo;
    float intro_countdown;

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
            Logo.SetActive(false);
            Menu.SetActive(true);
            gameObject.GetComponent<IntroScript>().enabled = false;
        }
        else
            intro_countdown -= Time.deltaTime;
    }
}
