using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public List<StationObject> stations;
    public int energyAmount = 0;
    public int crystalAmount = 0;

    [Header("Button")]
    public Button editButton;

    [Header("Text Displays")]
    [SerializeField] private TMP_Text energyAmountText;
    [SerializeField] private TMP_Text crystalAmountText;

    public bool editModeActive = false;

    private void Start()
    {
        energyAmount = 50;
    }

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

        editButton.onClick.AddListener(EnableEditMode);
    }

    private void EnableEditMode()
    {
        foreach (StationObject station in stations)
        {
            station.mode = Mode.editMode;
            editModeActive = true;
        }
    }

    public void DisableEditMode()
    {
        foreach (StationObject station in stations)
        {
            station.mode = Mode.buildMode;
            editModeActive = false;
        }
    }
}
