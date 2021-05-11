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
		PlayerMovement.bombsAvailable++;
		Debug.Log(PlayerMovement.bombsAvailable);
		Destroy(this.gameObject);
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
						Destroy(collider.gameObject);
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
