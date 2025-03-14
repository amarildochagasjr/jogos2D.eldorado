using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            FindAnyObjectByType<SoundFXController>().PlayEnemyDeath();
        }

        if(collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            FindAnyObjectByType<SoundFXController>().eggInGround();
        }
    }
}
