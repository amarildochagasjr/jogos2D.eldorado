using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour
{
   AudioSource audioSource;

    public AudioClip enemyDeath, eggGround, playerDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   public void PlayEnemyDeath()
   {
        audioSource.PlayOneShot(enemyDeath);
   }

   public void PlayPlayerDeath()
   {
        audioSource.PlayOneShot(playerDeath);
   }

   public void eggInGround()
   {
        audioSource.PlayOneShot(eggGround);
   }
}
