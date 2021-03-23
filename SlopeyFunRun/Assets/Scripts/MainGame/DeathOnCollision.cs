using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<GameManager>().DoGameOver();
    }
}
