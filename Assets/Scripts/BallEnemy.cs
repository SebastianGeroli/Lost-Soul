using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public partial class BallEnemy : MonoBehaviour
{
    [SerializeField]
    float attackEveryXSeconds = 1f;
    [SerializeField]
    Transform anchorPosition;
    [SerializeField]
    float maxAttackDistance = 3f;
    [SerializeField]
    float reachMaxDistanceIn = 2f;
    bool gameOver = false;
    Vector2 translation;

    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack());
    }

    private void MoveTowardPlayer()
    {
        if (Vector2.Distance(anchorPosition.position, transform.position) >= maxAttackDistance)
        {
            return;
        }
        translation = Vector2.Lerp(transform.position, Utility.PlayerPos.position, Time.deltaTime / reachMaxDistanceIn);
        transform.Translate(translation - (Vector2)transform.position);

    }
    private void MoveTowardsOrigin()
    {
        translation = Vector2.Lerp(transform.position, anchorPosition.position, Time.deltaTime / reachMaxDistanceIn);
        transform.position = translation;
    }
    IEnumerator Attack()
    {
        float timer = 0;
        bool attack = true;
        while (gameOver == false)
        {
            if (attack)
            {
                timer += Time.deltaTime;
                MoveTowardPlayer();
                if (timer >= reachMaxDistanceIn)
                {
                    timer = 0;
                    attack = false;
                }
            }
            else
            {
                Debug.Log("Moving To origin");
                timer += Time.deltaTime;
                MoveTowardsOrigin();
                if (timer >= reachMaxDistanceIn / 2)
                {
                    timer = 0;
                    attack = true;
                }
            }

            yield return new WaitForEndOfFrame();
        }


    }
}
