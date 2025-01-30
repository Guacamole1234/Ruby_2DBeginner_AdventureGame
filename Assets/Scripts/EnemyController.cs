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
    // Start is called before the first frame update
    void Start()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
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
        Vector2 position = rigibody2d.position;
        if (vertical)
        {
            position.y = position.y + speed * Time.deltaTime;
        }
        else
        {
            position.x = position.x + speed * Time.deltaTime;
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
}
