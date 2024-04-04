using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    [SerializeField] Inventory inventory;
    [SerializeField] static LayerMask isGround;

    public GridLayout gridLayout;
    private Grid grid;

    [Header("Tiles")]

    [SerializeField] Tile defaultTile;
    [SerializeField] Tile freeTile;
    [SerializeField] Tile occupiedTile;

    [SerializeField] private Tilemap tilemap;

    public PlaceableObject objectToPlace;



    // [SerializeField] private int currentStationIndex = 0;

    private void Start()
    {
        current = this;
        grid = gridLayout.gameObject.transform.GetComponent<Grid>();
    }

    public static Vector3 GetWorldMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            return hitInfo.point;
        }
        else
            return Vector3.zero;
    }

    public Vector3 SnapCoordinateTo(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    public void InitalizeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateTo(Vector3.zero);
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        inventory.AddToInventory(obj.GetComponent<StationObject>());
    }
}