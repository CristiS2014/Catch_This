﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreSpeed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //col.gameObject.GetComponent<PlayerMovement>().IncreaseSpeed();
            //Debug.Log("Haide");
            //Destroy(this.gameObject);
            GameObject.Find("Level Manager").GetComponent<PhotonView>().RPC("GivePowerUp", PhotonTargets.AllViaServer,
                                                                            col.gameObject.GetComponent<PhotonView>().viewID,
                                                                            this.gameObject.GetComponent<PhotonView>().viewID,
                                                                            2);
        }
    }

    [PunRPC]
    public void DestroyPowerUp()
    {
        Destroy(this.gameObject);
    }
}
