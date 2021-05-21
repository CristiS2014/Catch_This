using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Explosion : MonoBehaviour
{

	[SerializeField]
	private BoxCollider2D collider2D;

	[SerializeField]
	private GameObject explosionPrefab;

	[SerializeField]
	private int explosionRange;

	[SerializeField]
	private float explosionDuration;

	[SerializeField]
	private GameObject SpeedPower;

	[SerializeField]
	private GameObject BombsPower;

	[SerializeField]
	private GameObject HealthPower;

	public PhotonView phView;

	void OnTriggerExit2D(Collider2D other)
	{
		this.collider2D.isTrigger = false;
	}

	public void Explode()
	{
		GameObject explosion = Instantiate(explosionPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
		Destroy(explosion, this.explosionDuration);
		CreateExplosions(Vector2.left);
		CreateExplosions(Vector2.right);
		CreateExplosions(Vector2.up);
		CreateExplosions(Vector2.down);
		if (phView.isMine)
		{
			PlayerMovement.bombsAvailable++;
			PhotonNetwork.Destroy(this.gameObject);
		}
	}

	private void CreateExplosions(Vector2 direction)
	{
		ContactFilter2D contactFilter = new ContactFilter2D();
		Vector2 explosionDimensions = explosionPrefab.GetComponent<SpriteRenderer>().bounds.size;
		Vector2 explosionPosition = (Vector2)this.gameObject.transform.position + (explosionDimensions.x * direction);
		for (int explosionIndex = 1; explosionIndex < explosionRange; explosionIndex++)
		{
			Collider2D[] colliders = new Collider2D[4];
			Physics2D.OverlapBox(explosionPosition, explosionDimensions, 0.0f, contactFilter, colliders);
			bool foundBlockOrWall = false;
			foreach (Collider2D collider in colliders)
			{
				if (collider)
				{
					foundBlockOrWall = collider.tag == "Wall" || collider.tag == "Box" || collider.tag == "Player";
					if (collider.tag == "Box" || collider.tag == "Player")
					{
						if(collider.tag == "Box")
                        {
							if (!PhotonNetwork.isMasterClient && PhotonNetwork.playerList.Length > 1)
                            {
								Destroy(collider.gameObject);
								continue;
                            }
							Debug.Log("Here");
							PhotonView phView = GameObject.Find("Level Manager").GetComponent<PhotonView>();
							var number = Random.Range(1, 15);
							if (number == 1 || number == 2 || number == 6)
								phView.RPC("SpawnPowerUp", PhotonTargets.MasterClient, collider.gameObject.transform, 1);
							//Instantiate(BombsPower, collider.gameObject.transform.position, Quaternion.identity);
							else if (number == 3 || number == 4 || number == 7)
								//Instantiate(SpeedPower, collider.gameObject.transform.position, Quaternion.identity);
								phView.RPC("SpawnPowerUp", PhotonTargets.MasterClient, collider.gameObject.transform, 2);
							else if (number == 5 || number == 8)
								//Instantiate(HealthPower, collider.gameObject.transform.position, Quaternion.identity);
								phView.RPC("SpawnPowerUp", PhotonTargets.MasterClient, collider.gameObject.transform, 3);

							Destroy(collider.gameObject);
						}

						if (collider.tag == "Player")
                        {
							collider.gameObject.GetComponent<PlayerMovement>().DestroyPlayer();
                        }
					}

					if (foundBlockOrWall)
					{
						break;
					}
				}
			}
			if (foundBlockOrWall)
			{
				break;
			}
			GameObject explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity) as GameObject;
			Destroy(explosion, this.explosionDuration);
			explosionPosition += (explosionDimensions.x * direction);
		}
	}
}
