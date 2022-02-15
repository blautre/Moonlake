using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : NetworkBehaviour
{
    private Rigidbody playerBody;
    private Transform playerTransform;
    private PlayerData playerData;

    private Vector3 moveDirection;
    public Vector3 playerLastPosition;


    private float moveSpeed = 100f;

    public float actualSpeed;
    public float desiredSpeed;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        playerData = GetComponent<PlayerData>();

    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float speed = playerData.speed;
        if (isLocalPlayer)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // Take vertical and horizontal user input and store it in the vector

            playerBody.velocity = moveSpeed * speed * Time.deltaTime * moveDirection.normalized; // constant velocity is input * character's speed stat * movement speed
        }

        desiredSpeed = playerBody.velocity.magnitude;
        actualSpeed = Vector3.Distance(playerTransform.position, playerLastPosition) / Time.deltaTime;
        playerLastPosition = playerTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>()); //Ignore collition with other players
        }
    }
}