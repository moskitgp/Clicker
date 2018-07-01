using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour {

    private static FloatingTextManager instance;

    public GameObject textPrefab;
    public RectTransform clickButtonTransform;

    public static FloatingTextManager Instance{
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<FloatingTextManager>();
            }
            return instance;
        }
    }

    public void CreateText(Vector3 position, string text){
        GameObject popupText = Instantiate(textPrefab, position, Quaternion.identity);
        popupText.transform.SetParent(clickButtonTransform);
        popupText.GetComponent<RectTransform>().localScale = new Vector3 (1,1,1);
        popupText.GetComponent<Text>().text = text;
    }



}
