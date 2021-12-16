using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;

    public HealhBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("GameOver");
        }

    }
    // Update is called once per frame
    public void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
