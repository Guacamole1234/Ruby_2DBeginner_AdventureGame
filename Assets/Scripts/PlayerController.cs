using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class PlayerController : MonoBehaviour
{
    // Variables relacionadas con el movimiento del jugador
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3f;

    // Variables relacionadas con el sistema de vida
    public int maxHealth = 5;
    public int health { get { return currentHealth; } } /*The property definition is similar to a variable declaration. It has an access level keyword (public), a type (int), and a name (health). This definition then has some unfamiliar syntax: two sets of braces (code blocks), one nested inside the other. The outer block contains the keyword get and a second block. True to its name, the purpose of the keyword is to get whatever is in the nested block so that information can be read in other scripts.The inner block returns the currentHealth value. The compiler treats this block like a normal function, so you can add instructions to declare a variable, complete computations or call other functions here. However, in this case all you need to do is get the value of the currentHealth variable. */
    int currentHealth;

    //Variables sobre invencibilidad temporal
    public float timeInvincible = 2f;
    bool isInvincible;
    float damageCooldown;


    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 3f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }
}
