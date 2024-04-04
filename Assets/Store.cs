using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    public BuildingSystem buildingSystem;
    public Inventory inventory;
    public List<GameObject> store;

    public void BuyStation(GameObject prefab)
    {
        if (prefab.GetComponent<StationObject>().station.valueType == ValueType.Energy && inventory.energyAmount >= prefab.GetComponent<StationObject>().station.cost)
        {
            buildingSystem.InitalizeWithObject(prefab);
            inventory.energyAmount -= prefab.GetComponent<StationObject>().station.cost;
        }
        else if (prefab.GetComponent<StationObject>().station.valueType == ValueType.Crystal && inventory.energyAmount >= prefab.GetComponent<StationObject>().station.cost)
        {
            buildingSystem.InitalizeWithObject(prefab);
            inventory.energyAmount -= prefab.GetComponent<StationObject>().station.cost;
        }
    }
}
