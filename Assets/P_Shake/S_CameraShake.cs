using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraShake : MonoBehaviour
{
    [SerializeField]
    Transform cam; //agregar la camara desde inspector

    [SerializeField] float duracion; //en segundos
    [SerializeField] float amplitud;

    [SerializeField] float transcurrido;

 
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine("shake");
            Debug.Log("Shake");
        }
    }


    IEnumerator shake() {

        Vector3 posicion_original = cam.position; //or localposition

        transcurrido = 0;
        float x, y; //podria tambien ser z (profundidad)
        while (transcurrido<duracion)
        {
            x = Random.Range(-1f, 1f) * amplitud; //max = 1 min  = 0
            y = Random.Range(-1f, 1f) * amplitud;

            cam.position = new Vector3(posicion_original.x + x,
                posicion_original.y + y,
                posicion_original.z
                );

            transcurrido += Time.deltaTime;

            yield return null;
        }

        cam.position = posicion_original;

    }


}
