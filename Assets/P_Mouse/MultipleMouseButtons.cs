using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleMouseButtons : MonoBehaviour
{
    [SerializeField]
    bool[] botones_mouse;

    private void Awake()
    {
        botones_mouse = new bool[7];
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            botones_mouse[i] = Input.GetKey("mouse " + i); 
        }
    }
}
