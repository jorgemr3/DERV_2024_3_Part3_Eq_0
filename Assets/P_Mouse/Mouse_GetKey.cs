using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_GetKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //"Fire1"
        {
            Debug.Log("Click Izquierdo");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Click Derecho");
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log("Click Central");
        }


    }
}
