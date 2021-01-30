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
    float movementSpeed = 2f;
    [SerializeField]
    bool gameOver = false;
    Vector2 translation;
    bool isInRange = false;

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
        translation = Vector2.Lerp(transform.position, Utility.PlayerPos.position, Time.deltaTime * movementSpeed);
        transform.Translate(translation - (Vector2)transform.position);

    }
    private void ChangeAttack(bool attack)
    {
        this.isInRange = attack;
    }
    private void MoveTowardsOrigin()
    {
        translation = Vector2.Lerp(transform.position, anchorPosition.position, Time.deltaTime * movementSpeed / 2);
        transform.position = translation;
    }
    IEnumerator Attack()
    {
        float timer = 0;
        float timer2 = 0;
        while (gameOver == false)
        {
            if (isInRange)
            {
                timer += Time.deltaTime;
                MoveTowardPlayer();
                if (timer >= movementSpeed)
                {
                    MoveTowardsOrigin();
                    timer2 += Time.deltaTime;
                    if (timer2 >= movementSpeed / 2)
                    {
                        timer = 0;
                        timer2 = 0;
                    }
                }
            }
            else
            {
                timer = 0;
                timer2 = 0;
                MoveTowardsOrigin();
            }

            yield return new WaitForEndOfFrame();
        }


    }
}
