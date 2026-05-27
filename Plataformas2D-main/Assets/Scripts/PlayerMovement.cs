
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float force = 2500f;

    public Vector2 direction;
    Animator animator;
    SpriteRenderer sr;
    GroundDetector ground;

    public bool movingRight;

    void Start()
    {
        // inicializamos componentes
        ground = GetComponent<GroundDetector>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (this == null) return; // por si se ha eliminado

        // leemos el input del movimiento del input system (WASD o joystick)
        direction = GameManager.instance.actions.Player.Move.ReadValue<Vector2>();
        // si se mueve el personaje hacia la derecha
        if(direction.x > 0) {
            animator.SetBool("isRunning", true); // animacion de correr
            sr.flipX = false; // sprite mirando a la derecha
            movingRight = true;
        }
        // si se mueve a la izquierda
        else if (direction.x < 0)
        {
            animator.SetBool("isRunning", true); // animacion de correr
            sr.flipX = true; // sprite mirando a la izquierda (lo flipeamos)
            movingRight = false;
        }
        // si es = 0, no se esta moviendo, volvemos al idle
        else {
            animator.SetBool("isRunning", false);
        }
        // si el personaje salta
        if (ground.isGrounded)
        {
            if (GameManager.instance.actions.Player.Jump.WasPressedThisFrame())
            {
                animator.SetBool("isJumping", true); // animacion saltar (tiene un evento al final que la desactiva cuando acaba la animacion)
                rb.AddForce(Vector2.up * force); // añadimos fuerza ( SE PODRIA HACER CON UN IMPLUSE TRANSFORM UP)
            }
        }
        // si el personaje ataca (left click, enter o joystick)
        if (GameManager.instance.actions.Player.Attack.WasPressedThisFrame())
        {
            GameManager.instance.actions.Disable(); // desactivamos para que no pueda hacer nada mas que atacar
            animator.SetBool("isAttacking", true); // animacion atacar (tiene un evento al final que la desactiva cuando acaba la animacion)
        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
    }

    // funcion para desactivar la animacion del jumping
    public void setIsJumpingFalse()
    {
        animator.SetBool("isJumping", false);
    }
    // funcion para desactivar la animacion del attacking
    public void setIsAttackingFalse()
    {
        animator.SetBool("isAttacking", false);
        GameManager.instance.actions.Enable();
    }

}