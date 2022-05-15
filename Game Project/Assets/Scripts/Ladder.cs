using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topcollider;
    public Text interactUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("interactUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // permet de descendre de l'echelle 
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topcollider.isTrigger = true;
        }
    }

    // Dans la zone de l'echelle 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            interactUI.enabled = false;
        }

    }
}
