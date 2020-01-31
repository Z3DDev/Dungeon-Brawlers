using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int hp = 1;

    public void dmgObstacle(int loss) {
        hp -= loss;

        if(hp <= 0) {
            gameObject.SetActive(false);
        }
    }
}
