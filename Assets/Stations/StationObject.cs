using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StationObject : MonoBehaviour
{
    public Station station;
    public int increasePerSecond = 1;
    public int upgrade = 1;

    public GameObject damageTextPrefab;

    [SerializeField] public float timer = 1;

    private float _maxTime = 2;

    public Mode currentMode = Mode.buildMode;

    private void Update()
    {
        damageTextPrefab.GetComponent<TMP_Text>().text = "+" + increasePerSecond;
        if (timer <= 0)
        {
            timer = _maxTime;
            Instantiate(damageTextPrefab, transform);
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "+" + increasePerSecond;
        }
        timer -= Time.deltaTime;
    }

    private Vector3 _lastMousePos;

    private Vector3 positionOffset;

    private void OnMouseDown()
    {
        if (currentMode == Mode.editMode)
        {
            positionOffset = transform.position - BuildingSystem.GetWorldMousePosition();
        }
    }

    private void OnMouseDrag()
    {
        if (currentMode == Mode.editMode)
        {
            Vector3 pos = BuildingSystem.GetWorldMousePosition() + positionOffset;
            if (!BuildingSystem.current.IsTileOccupied(BuildingSystem.current.gridLayout.WorldToCell(pos)))
            {
                transform.position = BuildingSystem.current.SnapCoordinateTo(pos);
            }
        }
    }
}

public enum Mode
{
    editMode,
    buildMode
}