using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - BuildingSystem.GetWorldMousePosition();
    }

    private void OnMouseDrag()
    {
        Vector3 pos = BuildingSystem.GetWorldMousePosition() + offset;
        transform.position = BuildingSystem.current.SnapCoordinateTo(pos);
    }
}
