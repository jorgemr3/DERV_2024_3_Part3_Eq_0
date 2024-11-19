using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_MousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//clic izquierdo
        {
            Vector3 v = Input.mousePosition; 
            Debug.Log(v);
        }
    }
}
