using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public AudioClip hitsound;


    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(50);

        }
    }
 

    public void TakeDamage(int damage)
    {
        // mode invicible apres des degats
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitsound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            // verification pour voir si le joueur est toujours vivant
            if(currentHealth <= 0)
            {
                Death();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }

    }

    public void Death()
    {
        Debug.Log("Le joueur est mort");
        // le personnage ne peut plus bouger 
        PlayerMovement.instance.enabled = false;
        // jouer l'animation de mort
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        // empecher les interactions physiques 
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        Debug.Log("Le joueur est mort");
        // le personnage ne peut  re bouger 
        PlayerMovement.instance.enabled = true;
        // jouer l'animation de respawn
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        // activer les interactions physiques 
        PlayerMovement.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;        
        }else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        // transparent apres avoir reçu des degats 
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }

    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}