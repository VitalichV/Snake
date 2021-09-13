using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material setColor;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Смена цвета");
        other.GetComponent<Renderer>().material.color = setColor.color;
    }
}
