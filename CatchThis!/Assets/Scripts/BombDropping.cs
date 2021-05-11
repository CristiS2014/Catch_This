using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropping : MonoBehaviour
{

	[SerializeField]
	private GameObject bombPrefab;

	public static int bombs;

	void Start()
	{
		bombs = 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space") && bombs > 0)
		{
			DropBomb();
			bombs--;
		}
	}

	void DropBomb()
	{
		Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity);
	}
}

