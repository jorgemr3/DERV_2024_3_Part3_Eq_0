using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_TomarObjetos : MonoBehaviour
{
    bool objetoCerca;
    GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objetoCerca){
            if(Input.GetKeyDown(KeyCode.F)){
                    Debug.Log("Tomaste el objeto");
                    objeto.transform.SetParent(transform);
                    Rigidbody rb = objeto.GetComponent<Rigidbody>();
                    rb.useGravity =false;
                    rb.isKinematic = true;
                    objeto.transform.position = transform.position;
                    objeto.transform.rotation = transform.rotation;
                }
            if (Input.GetKeyUp(KeyCode.F)){
                    Debug.Log("Liberaste el objeto");
                    objeto.transform.SetParent(null);                    
                    Rigidbody rb = objeto.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    //objeto.transform.position = transform.position;
                    //objeto.transform.rotation = transform.rotation;
                }
        }
    }

    private void OnTriggerEnter(Collider other) {
            GameObject obj = other.gameObject;
            Debug.Log("Entro en Trigger con: "+ obj.name);
            if(obj.CompareTag("ObjetoTomable")){
                objetoCerca = true;
                objeto = obj;
            }
    }

    private void OnTriggerExit(Collider other) {
        GameObject obj = other.gameObject;
            Debug.Log("Sale de Trigger con: "+ obj.name);
            if(obj.CompareTag("ObjetoTomable")){
                objetoCerca = false;
                objeto = null;
            }
    }

}
