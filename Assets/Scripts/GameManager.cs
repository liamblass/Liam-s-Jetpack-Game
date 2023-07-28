using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float startingFuel;
    [SerializeField] private float fuelUse;
    [SerializeField] private float fuelCollectible;
    [SerializeField] private Image fuelBar;

    private float currentFuel;
    public bool canThrust;

       private void Start()
    {        
        currentFuel = startingFuel;
    }

    private void Update()
    {
        CheckFuel();
        UpdateFuelBar();
    }
     
    private void CheckFuel()
    {
        if (currentFuel > 0)
            canThrust = true;

        if (currentFuel <= 0)
        {
            canThrust = false;
            PlayerDead();
        }
    }
    public void UseFuel()
    {
        if (currentFuel > 0)
        {        
            currentFuel -= fuelUse;
        }
    }

    public void AddFuel()
    {
        currentFuel += fuelCollectible;
    }

    private void UpdateFuelBar()
    {
        float fuelPercentage = currentFuel / startingFuel;  

        fuelBar.fillAmount = fuelPercentage;  
    }

    public void PlayerDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
