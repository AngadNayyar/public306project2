using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{
    public int startingHealth = 100;                            // Health that Charlie starts with.
    public int currentHealth;                                   // Charlie's current health.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to the Damage Image.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour of the damageImage

    bool isDead;                                                // Whether Charlie is dead.
    bool damaged;                                               // True when the Charlie takes damage.

    private GameController gameController;

    void Awake(){
        currentHealth = startingHealth;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update(){
        // If player takes damage, make the screen flash. Otherwise, change the damage colour to clear
        if (damaged){
            damageImage.color = flashColour;
        }
        else{
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Change damage boolean to false
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        //Change damaged boolean to true, makes the screen flash
        damaged = true;

        //Deduct amount from current health.
        currentHealth -= amount;

        //Update the health bar to reflect new health.
        healthSlider.value = currentHealth;

        // If Charlie loses all health and isn't dead, kill him.
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        } else
        {
            PlayerPrefs.SetInt("endHealth", currentHealth);
        }
    }
    void Die()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        Time.timeScale = 0;
        gameController.PlayerDied();
    }
}