using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaEnemy : MonoBehaviour
{
    [SerializeField]
    private float timeToReachTop;

    [SerializeField]
    private float timeToReachBottom;

    [SerializeField]
    private float delayToStartMoving = 0f;

    [SerializeField]
    private Transform lava;

    [SerializeField]
    private Transform topPosition;

    [SerializeField]
    private Transform bottomPosition;

    public bool gameOver = false;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private bool goingUp = true;

    private void MoveToTop()
    {
        Vector2 translation = Vector2.Lerp(lava.position, topPosition.position, Time.deltaTime / timeToReachTop);
        lava.Translate(translation - (Vector2)lava.position);
    }
    private void MoveToBottom()
    {
        Vector2 translation = Vector2.Lerp(lava.position, bottomPosition.position, Time.deltaTime / timeToReachBottom);
        lava.Translate(translation - (Vector2)lava.position);
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(delayToStartMoving);
        float timer = 0;
        while (gameOver == false)
        {
            if (timer <= timeToReachTop)
            {
                MoveToTop();
                timer += Time.deltaTime;
            }
            else if (timer <= timeToReachTop + timeToReachBottom)
            {
                MoveToBottom();
                timer += Time.deltaTime;
            }
            else if (timer > timeToReachBottom + timeToReachBottom)
            {
                timer = 0;
            }
            yield return new WaitForEndOfFrame();
        }


    }


}
