using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    InputHandler inputHandler; 
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        //mendapatkan reference komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren <PlayerShooting>();
        inputHandler = GetComponent<InputHandler>();

        //playerShooting = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        //jika kena hit
        if (damaged)
        {
            //merubah warna gambar menjadi value dari flashColour
            damageImage.color = flashColour;
        }
        else
        {
            //Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //matiin damage
        damaged = false;
    }

    // fungsi untuk dapet damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        //mengurangi damage
        currentHealth -= amount;

        //merubah tampilan health
        healthSlider.value = currentHealth;

        //memainkan suara ketika kena hit
        playerAudio.Play();

        //memanggil method death
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    private void Death()
    {
        isDead = true;
        
        //mematikan move player
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        inputHandler.enabled = false;

        playerShooting.DisableEffects();

        //mentrigger animasi die
        anim.SetTrigger("IsDie");

        //menyalakan suara ketika mati
        playerAudio.clip = deathClip;
        playerAudio.Play();

        
    }
}