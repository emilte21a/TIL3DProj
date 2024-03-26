using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(gameObject);
    }
}
