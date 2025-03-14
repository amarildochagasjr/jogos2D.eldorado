using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    
    AudioSource getEggItem;

    public AudioClip getItemSound;
    
    // Start is called before the first frame update
    void Start()
    {
        getEggItem = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   public void PlayGetItem()
   {
        getEggItem.PlayOneShot(getItemSound);
   }
}
