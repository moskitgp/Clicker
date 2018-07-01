using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingText : MonoBehaviour {

    public float DestroyTime = 1.5f;
    

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }




}
