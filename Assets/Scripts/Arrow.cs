using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject explosion;
    public Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);// a unity cria varios objetos que sao as flechas sendo atiradas, esse comando destroi os gameobject criados
    }


    private void FixedUpdate()
    {
       Vector2 direction = transform.position + transform.right * speed * Time.deltaTime;
       


        rb.MovePosition(direction);

        /*
        transform.position representa a posição atual do objeto no espaço 2D.
        transform.right é um vetor que aponta para a direção da frente do objeto (ou seja, o eixo x positivo).
        speed é uma variável que determina a velocidade do movimento.
        Time.deltaTime é o tempo decorrido desde o último quadro renderizado.
        A linha calcula a nova posição (direction) adicionando o deslocamento 
        na direção da frente multiplicado pela velocidade e ajustado pelo tempo.
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Enemy"))
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 1f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
