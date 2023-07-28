using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float hightAbovePlayer = 5;

    [Header("CHANCES")]
    [SerializeField] private float fuelChance;
    

    [Header("TRANSFORMS")]
    [SerializeField] private Transform trapPerent;
    [SerializeField] private Transform FuelPerent;

    [Header("PREFABS")]
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject fuelPrefab;

    private void OnEnable()
    {
        Shreder.onObjactDestroid += SpawnObject;
    }

    private void OnDisable()
    {
        Shreder.onObjactDestroid -= SpawnObject;
    }

    private void Update()
    {
        Invoke("SpawnObject()", 1.5f);
    }

    private void SpawnObject()
    {
        GameObject toSpwan = GetObjectToSpwan();

        Vector2 spwanPosScreen = new Vector2(Random.Range(0, Screen.width), Screen.height * Random.Range(1.1f, 1.3f));

        Vector2 spawnPosWorld = Camera.main.ScreenToWorldPoint(spwanPosScreen);

        Instantiate(
            toSpwan,
            spawnPosWorld,
            Quaternion.identity,
            trapPerent);
    }


    private GameObject GetObjectToSpwan()
    {
        float rand = Random.Range(0f, 1f);

        if (rand < fuelChance)
        {
            return trapPrefab;
        }
        else
        {
            return fuelPrefab;
        }
    }
}
