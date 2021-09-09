using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] bool RightMovement;

    float minX, maxX;
    int puntosdeVida = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;



    }

    // Update is called once per frame
    void Update()
    {
        if(RightMovement)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

        }

        if (transform.position.x >= maxX)
        {
            //que se mueva a la izq
            RightMovement = false;
        }
        else if(transform.position.x <= minX)
        {
            //que se mueva a la der
            RightMovement = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        int puntos = collision.gameObject.GetComponent<Bullet>().darPuntosDano();
        puntosdeVida = puntosdeVida - puntos;

        if (collision.gameObject.CompareTag("Shot"))
        {
            (GameObject.Find("GameManager").GetComponent<GameManager>()).KillAnimals();
          
                Destroy(this.gameObject);


        }
       
    }

}
