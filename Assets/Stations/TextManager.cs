using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(0, Camera.main.gameObject.transform.parent.transform.eulerAngles.y + 45, 0);
    }
}
