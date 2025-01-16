using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1f;
        }
     else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = +1f;
        }
     Debug.Log(horizontal);
        if (Keyboard.current.upArrowKey.isPressed)
        {
            horizontal = +1f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            horizontal = -1f;
        }


        Vector2 position = transform.position;
        position.x = position.x + 0.01f * horizontal;
        position.y = position.y + 0.01f * vertical;
        transform.position = position;
    }
}
