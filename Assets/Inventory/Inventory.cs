using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public List<StationObject> stations;
    public int energyAmount = 0;
    public int crystalAmount = 0;


    [Header("Text Displays")]
    [SerializeField] private TMP_Text energyAmountText;
    [SerializeField] private TMP_Text crystalAmountText;

    public void AddToInventory(StationObject stationObject)
    {
        stations.Add(stationObject);
    }

    public void RemoveFromInventory(StationObject stationObject)
    {
        stations.Remove(stationObject);
    }

    private void Update()
    {
        energyAmountText.text = $"{energyAmount}";
        crystalAmountText.text = $"{crystalAmount}";

        foreach (var station in stations)
        {
            if (station.timer <= 0)
            {
                if (station.station.valueType == ValueType.Energy)
                {
                    energyAmount += station.increasePerSecond * station.upgrade;
                }

                else if (station.station.valueType == ValueType.Crystal)
                {
                    crystalAmount += station.increasePerSecond * station.upgrade;
                }
            }

        }
    }
}
