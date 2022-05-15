using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioClip flagsound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            CurrentSceneManager.instance.respawnPoint = transform.position;
            AudioManager.instance.PlayClipAt(flagsound, transform.position);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
