using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLife : MonoBehaviour
{

    Image valorVida;

    [SerializeField] float vida;
    float damage;

    // Start is called before the first frame update
    void Start()
    {
        vida = 1; //toda la vida
        valorVida = GameObject.Find("Vida").GetComponent<Image>();
        valorVida.fillAmount = vida;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            damage = Random.Range(0f, 1f);
            vida -= damage;
            valorVida.fillAmount = vida;
        }
    }
}
