using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3f;

    Rigidbody2D rigibody2d;
    float timer;
    int direction = 1;

    Animator animator;

    bool broken = true;

    public ParticleSystem smokeEffect;

    void Start()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = rigibody2d.position;
        if (vertical)
        {
            position.y = position.y + speed * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigibody2d.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigibody2d.simulated = false;
        smokeEffect.Stop();
    }
}
