using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : Photon.MonoBehaviour
{
    public int movementspeed = 2;
    public PhotonView phView;
    public static int bombsAvailable = 0;
    public Text playerName;
    [SerializeField]
    private GameObject bombPrefab;

    // Use this for initialization
    void Start()
    {
        if (phView.isMine || !PhotonNetwork.connected)
        {
            bombsAvailable = 1;
        }

        if (phView.isMine)
        {
            playerName.text = PhotonNetwork.player.NickName;
        } else
        {
            playerName.text = photonView.owner.NickName;
            playerName.color = Color.cyan;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (phView.isMine || !PhotonNetwork.connected)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementspeed * Time.deltaTime);
        }

        if (Input.GetKeyDown("space") && bombsAvailable > 0)
        {
            DropBomb();
            bombsAvailable--;
        }
    }

    void DropBomb()
    {
        Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
