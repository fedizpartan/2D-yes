using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour

{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject disparador;
    [SerializeField] float fireRate;
    [SerializeField] GameObject balaRafaga;

    float minX, maxX, minY, maxY;
    float nextFire = 0;
    bool cambiarBala = true;
    float nextRafaga = 0;


    // Start is called before the first frame update
    void Start()
    {

        Vector2 esquinaSD = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMiny = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));



        maxX = esquinaSD.x - 0.7f;
        maxY = esquinaSD.y - 0.7f;
        minX = puntoMiny.x + 0.7f;
        minY = puntoMiny.y;
    }

    // Update is called once per frame
    void Update()
    {

        MoverNave();
        if (cambiarBala)
            Disparar();
        else
            DispararRafaga();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cambiarBala)
                cambiarBala = false;
            else
                cambiarBala = true;
        }

            cambiarBala = cambiarBala ? false : true;



    }



  void Disparar()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }

    }



    void DispararRafaga()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(balaRafaga, disparador.transform.position, transform.rotation);
            nextFire = Time.time + (fireRate / 3);
        }
    }

    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);

        transform.Translate(movimiento);

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.y, minY);
        }
    }

 
   

}
