using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMouseCoords : MonoBehaviour
{
    public string playerToMouse;

    public string camRay;

    public string floorHit;

    public string position;
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = Input.mousePosition.ToString()+ playerToMouse+"+"+camRay+"+"+floorHit+position;
    }
}
