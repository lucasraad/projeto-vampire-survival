using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public float speed;

    [Header("Arrow Attack")] //divide as referencias do player e da flecha na unity
    public Arrow arrow;
    public float FireRate;//quantidade de fechas spawnadas

    float timeCount; //controle de quantas flechas vao sair de acordo com o tempo que se passa



    Vector2 playerDirection; //armazena o eixo x e y do teclado


    // Update is called once per frame
    void Update()
    {                                      //GetAxis conseguimos acessar o eixo horizontal e vertical do teclado
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //troca GetAxis por GetAxisRaw para evitar do personagem derrapar

        timeCount += Time.deltaTime;
        //+= acrescido

        if(timeCount > FireRate)
        {
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) *Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(arrow, transform.position, rotation);

            timeCount = 0;
        }
            

        if (playerDirection.x > 0)
        {
            sprite.flipX = false; // ja esta virado para a direita
        }
        if (playerDirection.x < 0)
        {
            sprite.flipX = true; // virar para esquerda
        }

        //esta verificando se esta apertando algum butao do teclado
        if (playerDirection.sqrMagnitude > 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }

    private void FixedUpdate()
    {
       rb.MovePosition(rb.position + playerDirection.normalized * speed * Time.deltaTime);
     
    }
}
