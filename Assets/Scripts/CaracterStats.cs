using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaracterStats : MonoBehaviour
{
    
    public static characterName;
    public int maxHealth = 100;
    public TextMeshPro healthText;

    public Slider healthBar;
    public TextMeshPro healthText;

    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
    }


}
