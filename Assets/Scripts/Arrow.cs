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
        transform.position representa a posi��o atual do objeto no espa�o 2D.
        transform.right � um vetor que aponta para a dire��o da frente do objeto (ou seja, o eixo x positivo).
        speed � uma vari�vel que determina a velocidade do movimento.
        Time.deltaTime � o tempo decorrido desde o �ltimo quadro renderizado.
        A linha calcula a nova posi��o (direction) adicionando o deslocamento 
        na dire��o da frente multiplicado pela velocidade e ajustado pelo tempo.
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
