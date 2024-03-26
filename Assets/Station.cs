using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new station", menuName = "Station", order = 1)]
public class Station : ScriptableObject
{

    public string name;
    public int cost;
    public ValueType valueType;
}

public enum ValueType
{
    Crystal,
    Energy
}
