using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_GetMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click Izquiero");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Click Derecho");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Click Central");
        }
    }
}
