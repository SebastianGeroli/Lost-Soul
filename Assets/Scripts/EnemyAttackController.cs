using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyAttackController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BroadcastMessage("ChangeAttack", true, SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BroadcastMessage("ChangeAttack", false, SendMessageOptions.DontRequireReceiver);
        }
    }
}
