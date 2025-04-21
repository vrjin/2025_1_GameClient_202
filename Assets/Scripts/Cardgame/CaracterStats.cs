using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;

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

    public void UseMana(int amoint)
    {
        currentMana -= amoint;
        if (CurrentMana < 0)
        {
            currentMana = 0;
        }
        UpdateUI();
    }


}
