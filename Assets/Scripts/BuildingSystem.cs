using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    [SerializeField] Inventory inventory;
    [SerializeField] static LayerMask isGround;
    [SerializeField] LayerMask stationLayer;

    public GridLayout gridLayout;
    private Grid grid;

    [Header("Tiles")]

    [SerializeField] Tile defaultTile;
    [SerializeField] Tile freeTile;
    [SerializeField] Tile occupiedTile;

    [SerializeField] private Tilemap tilemap;

    public PlaceableObject objectToPlace;

    private void Start()
    {
        current = this;
        grid = gridLayout.gameObject.transform.GetComponent<Grid>();
    }

    private void Update()
    {
        UpdateTilemap();
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

    private bool IsTileOccupied(Vector3Int position)
    {
        Vector3 cellCenter = grid.GetCellCenterWorld(position);

        if (Physics.CheckBox(cellCenter, new Vector3(1, 1, 1), Quaternion.identity, stationLayer))
            return true;
        
        else
            return false;
        
    }

    public void UpdateTilemap()
    {
        BoundsInt bounds = tilemap.cellBounds;
        
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);

                if (inventory.editModeActive)
                {
                    if (IsTileOccupied(pos))
                    {
                        if (tile != occupiedTile)
                        {
                            tilemap.SetTile(pos, occupiedTile);
                        }
                    }
                    else 
                    {
                        if (tile != freeTile)
                        {
                            tilemap.SetTile(pos, freeTile);
                        }
                    }
                }
                else
                    tilemap.SetTile(pos, defaultTile);

            }
        }
    }
}