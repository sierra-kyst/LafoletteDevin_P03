using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private int maxHealth = 100;
    [Range(0, 100)] public int currentHealth;
    private int maxAmmo = 100;
    [Range(0, 100)] public int currentAmmo = 50;
    
    [SerializeField] private TMP_Text currentHealthTextView;
    [SerializeField] private TMP_Text currentAmmoTextView;
    [SerializeField] private TMP_Text currencyTextView;
    [SerializeField] private TMP_Text bonusPointsTextView;

    [HideInInspector] public int currency;
    [HideInInspector] public int bonusPoints;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentAmmo = maxAmmo;
    }

    public void Heal(int healthIncrease)
    {
        currentHealth += healthIncrease;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        currentHealthTextView.text = "Health: " + currentHealth.ToString() + "/100";
    }

    public void IncreaseAmmo(int ammoIncrease)
    {
        currentAmmo += ammoIncrease;
        if(currentAmmo>maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        currentAmmoTextView.text = "Ammo: " + currentAmmo.ToString() + "/100";
    }

    public void currencyCollect(int currencyIncrease)
    {
        currency += currencyIncrease;
        currencyTextView.text = "Gold: " + currency.ToString();
    }

    public void bonusCollect(int bonusIncrease)
    {
        bonusPoints += bonusIncrease;
        bonusPointsTextView.text = "Bonus: " + bonusPoints.ToString() + "/10";
    }
}
