using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    
    private void Awake()
    {
        SpawnPlayer();
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
}
