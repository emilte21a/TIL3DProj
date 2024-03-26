using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StationObject : MonoBehaviour
{
    public Station station;
    public int increasePerSecond;

    public int upgrade = 1;

    public GameObject damageTextPrefab;

    [SerializeField] public float timer = 1;

    private float _maxTime = 2;

    private void Update()
    {
        if (timer <= 0)
        {
            timer = _maxTime;
            Instantiate(damageTextPrefab, transform);
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "+" + increasePerSecond;
        }
        timer -= Time.deltaTime;


    }
}
