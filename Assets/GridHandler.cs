using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] LayerMask isGround;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inventory.stations.Count != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, isGround))
            {
                PlaceCubeNear(hitInfo.point, inventory.currentStation);
            }

        }
    }

    void PlaceCubeNear(Vector3 nearPoint, StationObject station)
    {
        Vector3 newPosition = new Vector3(Mathf.FloorToInt(nearPoint.x) * 10, Mathf.FloorToInt(nearPoint.y) * 10);
        StationObject newStation = Instantiate(station, newPosition, quaternion.identity);
        inventory.stations.Add(newStation);
    }
}