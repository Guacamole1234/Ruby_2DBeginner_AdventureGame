using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManagment : MonoBehaviour
{
    public static int enemyCount = 0;
    //Los enemigos al ser creados debe a�adirse a s� mismo. Los enemigos son creados/contabilizados al comenzar la partida.
    public void AddEnemy()
    {
        enemyCount++;
    }

    //Al pasar al estado "muerto" deben llamar a la funci�n.
    public void RemoveEnemy ()
    {
        enemyCount--;
    }
}
