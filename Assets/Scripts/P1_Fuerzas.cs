using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Fuerzas : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerza;


    // Start is called before the first frame update
    void Start()
    {
       // rb = GameObject.Find("Cube").GetComponent<Rigidbody>();        
        rb = GetComponent<Rigidbody>();    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {    
        //rb.AddForce(Vector3.right)    
       // rb.AddForce(transform.right * fuerza, ForceMode.Force);
       // rb.AddForce(transform.right * fuerza, ForceMode.Acceleration);

        //rb.AddForce(transform.right * fuerza, ForceMode.Impulse);

        rb.AddForce(transform.right * fuerza, ForceMode.VelocityChange);
        
    }
}
