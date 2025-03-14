using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContactHandler : MonoBehaviour
{

    public string nextLevel = "Level1";
    public string goToScene;
    public Image itemImage;
    public PlayerAudioController audioController;
    bool canWinLevel = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player tocou no inimigo.");

            Destroy(gameObject);

            FindAnyObjectByType<SoundFXController>().PlayPlayerDeath();

            SceneManager.LoadScene(goToScene);
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWinLevel)
            {
                Debug.Log("Player ganhou o jogo.");
                SceneManager.LoadScene(nextLevel);
            } else {
                Debug.Log("Player nao ganhou o jogo.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player pegou o item.");

            Destroy(collision.gameObject);

            itemImage.color = Color.white;

            canWinLevel = true;

            audioController.PlayGetItem();
        }

    }

}  
