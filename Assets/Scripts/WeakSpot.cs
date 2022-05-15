using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    
    public GameObject objectToDestroy;
    public AudioClip killsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killsound, transform.position);
            Destroy(objectToDestroy);
        }


    }
}
