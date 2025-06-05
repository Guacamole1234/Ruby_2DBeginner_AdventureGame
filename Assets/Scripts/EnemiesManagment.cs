using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManagment : MonoBehaviour
{
    public static int enemyCount = 0;
    public void AddEnemy()
    {
        enemyCount++;
    }

    public void RemoveEnemy ()
    {
        enemyCount--;
    }
}
