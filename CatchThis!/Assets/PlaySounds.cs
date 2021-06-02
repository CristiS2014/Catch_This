using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioSource deathSound;
    public AudioSource bombExplosion;
    public AudioSource pickupSound;

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayBombExplosion()
    {
        bombExplosion.Play();
    }
    public void PlayPickupSound()
    {
        pickupSound.Play();
    }
}
