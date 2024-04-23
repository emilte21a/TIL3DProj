using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public List<StationObject> stations;
    public int energyAmount = 0;
    public int crystalAmount = 0;

    [SerializeField] public Dictionary<ValueType, int> stationValues = new Dictionary<ValueType, int>();

    [Header("Button")]
    public Button editButton;

    [Header("Text Displays")]
    [SerializeField] private TMP_Text energyAmountText;
    [SerializeField] private TMP_Text crystalAmountText;

    public bool editModeActive = false;

    private void Start()
    {
        stationValues.Add(ValueType.Energy, 50);
        stationValues.Add(ValueType.Crystal, 0);
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
        energyAmountText.text = $"{stationValues[ValueType.Energy]}";
        crystalAmountText.text = $"{stationValues[ValueType.Crystal]}";


        foreach (var station in stations)
        {
            foreach (var KVP in stationValues)
            {
                if (station.timer <= 0)
                {
                    if (station.station.valueType.Equals(KVP.Key))
                    {
                        stationValues[KVP.Key] += station.increasePerSecond * station.upgrade;
                    }
                }
            }
        }

        editButton.onClick.AddListener(EnableEditMode);
    }

    private void EnableEditMode()
    {
        foreach (StationObject station in stations)
        {
            station.currentMode = Mode.editMode;
            editModeActive = true;
        }
    }

    public void DisableEditMode()
    {
        foreach (StationObject station in stations)
        {
            station.currentMode = Mode.buildMode;
            editModeActive = false;
        }
    }
}
