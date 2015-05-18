using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Slider shieldSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color shieldFlashColor = new Color(0f, 1f, 1f, .01f);

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerBuffs playerBuffs;
    bool isDead;
    bool damaged;
    bool shieldDamaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerBuffs = GetComponent<PlayerBuffs>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        shieldSlider.value = playerBuffs.armor;

        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else if (shieldDamaged)
        {
            damageImage.color = shieldFlashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        shieldDamaged = false;
    }

    public void TakeDamage(int amount)
    {
        if (playerBuffs.RemoveShieldTick())
        {
            shieldDamaged = true;
            shieldSlider.value = playerBuffs.armor;
            // Shield tick has been removed and no damage is taken

        }
        else
        { // No Shield was available, continue with damage
            damaged = true;

            currentHealth -= amount;

            healthSlider.value = currentHealth;

            playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
        }
    }

    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
