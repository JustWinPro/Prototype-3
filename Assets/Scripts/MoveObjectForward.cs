using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectForward : MonoBehaviour
{
    private float speed = 30;
    private Vector3 leftSpeed;
    private float leftBound = -15;

    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        leftSpeed = (Vector3.left * Time.deltaTime * speed);
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(leftSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
