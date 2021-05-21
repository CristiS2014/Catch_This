using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;

    private void Awake()
    {
        //SpawnPlayer();
        Invoke("SpawnPlayer", 2);
    }
    public void SpawnPlayer()
    {
        Transform spawnPointLocation = GameObject.Find(GameInfo.spawnPointName).transform;

        PhotonNetwork.Instantiate(playerPrefab.name,
                                  new Vector3(spawnPointLocation.position.x,
                                              spawnPointLocation.position.y,
                                              0),
                                  Quaternion.identity, 0);
    }

    [PunRPC]
    public void SpawnPowerUp(Transform location, int type)
    {
        if (type == 1)
        {
            PhotonNetwork.Instantiate("BomwP", new Vector3(location.position.x, location.position.y, 0), Quaternion.identity, 0);
        }
        else if (type == 2)
        {
            PhotonNetwork.Instantiate("Speed", new Vector3(location.position.x, location.position.y, 0), Quaternion.identity, 0);
        }
        else if (type == 3)
        {
            PhotonNetwork.Instantiate("pills", new Vector3(location.position.x, location.position.y, 0), Quaternion.identity, 0);
        }
    }
}