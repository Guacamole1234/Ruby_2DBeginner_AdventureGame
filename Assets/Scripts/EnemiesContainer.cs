using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesContainer : MonoBehaviour
{
    public int enemiesAlive;
    public int count { get { return enemiesTotal; } }
    public int enemiesTotal;

    void Start()
    {

    }

    void Total ()
    {
        enemiesTotal = count;
    }

    void Update()
    {
        
    }


}
