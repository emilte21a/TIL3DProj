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

    public Mode mode = Mode.buildMode;

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


    private Vector3 offset;

    private void OnMouseDown()
    {
        if (mode == Mode.editMode)
        {
            offset = transform.position - BuildingSystem.GetWorldMousePosition();
        }
    }

    private void OnMouseDrag()
    {
        if (mode == Mode.editMode)
        {
            Vector3 pos = BuildingSystem.GetWorldMousePosition() + offset;
            transform.position = BuildingSystem.current.SnapCoordinateTo(pos);
        }
    }
}

public enum Mode
{
    editMode,
    buildMode
}