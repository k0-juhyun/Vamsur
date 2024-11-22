using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        healthBarSlider.value = currentHealth;

        Debug.Log("Player took damage: " + damage + ". Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        gameObject.SetActive(false); // 플레이어 비활성화
    }
}






