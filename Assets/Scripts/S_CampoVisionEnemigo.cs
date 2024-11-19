using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CampoVisionEnemigo : MonoBehaviour
{
    [SerializeField]
    LayerMask layer_selected;

    [SerializeField]
    bool entra_campo_enemigo;

    [SerializeField]
    bool entra_angulo_vision_enemigo;
    [SerializeField]
    float anguloEntreVectores;

    [SerializeField]
    bool hay_obstaculos;

    //////////////////

    [SerializeField]
    Transform transform_jugador;

    [SerializeField]
    Vector3 puntoFrontal;
    Vector3 puntoIzquierdaVision;
    Vector3 puntoDerechaVision;

    //////////////////

    [SerializeField]
    float radioVision = 5f;

    [SerializeField]
    float anguloVision;

    //////////////////

    // Start is called before the first frame update
    void Start()
    {
        anguloVision = 90;
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobacion 1
        //CheckSphere CheckCapsule CheckBox
        entra_campo_enemigo = Physics.CheckSphere(transform.position, radioVision, layer_selected); //Soporta LayerMask Si fuera necesario
        //                                        posicion          radio

        //Si Comprobacion 1 es verdadera, entonces se realiza Comprobacion 2
        entra_angulo_vision_enemigo = IsOnAngleOfView();

        //Si Comprobacion 2 es verdadera, entonces se realiza Comprobacion 3
        hay_obstaculos = existenObstaculos();

        DrawFrenteVision();//Linea que sale del enemigo hacia su parte frontal
        DrawCircleVisionRadio();
        DrawVisionAngle();
    }

    //No es completamente compatible con el uso de Gizmos
    void DrawFrenteVision() {
        puntoFrontal = transform.position + transform.forward * radioVision;
        //puntoFrontal += new Vector3(0, 1, 0); //Para que el trazado no este a nivel de suelo. Es Opcional
        //Debe tenerse cuidado con la perspectiva si se emplea gizmos
        Debug.DrawLine(transform.position, puntoFrontal, Color.green);
    }

    //No es completamente compatible con el uso de Gizmos
    void DrawCircleVisionRadio() {
        int divisionesEnCirculo = 220; //configurable
        float angleStep = 360f / divisionesEnCirculo;

        Color c = Color.white;

        if (entra_campo_enemigo) {
            c = Color.red;
        }

        for (int i = 0; i < divisionesEnCirculo; i++)
        {
            float x, z;
            float x2, z2;

            x = radioVision * Mathf.Sin(Mathf.Deg2Rad * angleStep * i);
            z = radioVision * Mathf.Cos(Mathf.Deg2Rad * angleStep * i);

            x2 = radioVision * Mathf.Sin(Mathf.Deg2Rad * angleStep * (i+1));
            z2 = radioVision * Mathf.Cos(Mathf.Deg2Rad * angleStep * (i+1));

            Vector3 inicio = new Vector3(x, 1, z);  // y = 1 es para que el circulo no este a nivel de suelo. Valor configurable y Opcional
            Vector3 fin = new Vector3(x2, 1, z2);  // y = 1 es para que el circulo no este a nivel de suelo. Valor configurable y Opcional

            Debug.DrawLine(transform.position + inicio, transform.position + fin, c);

        }
    }

    void DrawVisionAngle() {
        float angulo1 = -Mathf.Deg2Rad * anguloVision / 2;
        float angulo2 = Mathf.Deg2Rad * anguloVision / 2;
        Vector3 frente2 = puntoFrontal - gameObject.transform.position;
        //Por matriz de rotacion...
        Vector3 limiteIzquierdo = new Vector3(frente2.x * Mathf.Cos(angulo1) + frente2.z * Mathf.Sin(angulo1), 1f, -frente2.x * Mathf.Sin(angulo1) + frente2.z * Mathf.Cos(angulo1));
        Vector3 limiteDerecho = new Vector3(frente2.x * Mathf.Cos(angulo2) + frente2.z * Mathf.Sin(angulo2), 1f, -frente2.x * Mathf.Sin(angulo2) + frente2.z * Mathf.Cos(angulo2));

        puntoIzquierdaVision = gameObject.transform.position + limiteIzquierdo;
        puntoDerechaVision = gameObject.transform.position + limiteDerecho;

        Debug.DrawLine(gameObject.transform.position + new Vector3(0,1,0), puntoIzquierdaVision, Color.blue);
        Debug.DrawLine(gameObject.transform.position + new Vector3(0, 1, 0), puntoDerechaVision, Color.blue);
    }

    bool existenObstaculos() {
        //el +1 u otro valor, es opcional, para que el rayo no salga a nivel de "suelo", sino que se ubique un poco por encima del jugador
        Vector3 origenRayo = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 destinoRayo = new Vector3(transform_jugador.position.x, transform_jugador.position.y + 1, transform_jugador.position.z);

        Vector3 direccionRayo = destinoRayo - origenRayo;

        Debug.DrawRay(origenRayo, direccionRayo);

        RaycastHit hit;

        if (Physics.Raycast(origenRayo, direccionRayo, out hit)) {
            if (hit.collider!=null && hit.collider.CompareTag("Player"))
            {
                return false; //Si choca contra el jugador, entonces no existes obstaculos
            }
        }

        return true;

    }

    bool IsOnAngleOfView() {
        
        Vector3 vEnemigo_a_Jugador = transform_jugador.position - transform.position;
        vEnemigo_a_Jugador.y = 0;

        Vector3 vEnemigo_a_PuntoFrontal = puntoFrontal - transform.position;
        vEnemigo_a_PuntoFrontal.y = 0;

        anguloEntreVectores = Vector3.Angle(vEnemigo_a_PuntoFrontal, vEnemigo_a_Jugador); 

        return anguloEntreVectores < anguloVision / 2;

    }

 

    private void OnDrawGizmos()
    {
        if (entra_campo_enemigo)
        {
            Gizmos.color = Color.yellow;           
        }
        else {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawWireSphere(transform.position, radioVision);
    }
}
