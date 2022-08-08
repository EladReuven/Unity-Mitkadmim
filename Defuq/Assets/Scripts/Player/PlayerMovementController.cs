using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Rigidbody rb;
    public float maxSpeed;
    [Min(0.01f)]
    public float TimeForMaxSpeed;
    [Min(0.01f)]
    public float TimeForHalt;

    float acceleration;
    float decelaration;
    float speed = 0f;
    Vector3 velocity;

    private void Start()
    {
        acceleration = maxSpeed / TimeForMaxSpeed * Time.timeScale;
        decelaration = maxSpeed / TimeForHalt * Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Clamp(speed, 0f, maxSpeed);

        if (Input.anyKey)
        {
            var movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

            speed += (acceleration + decelaration) * Time.deltaTime;
            velocity = speed * movementDirection;

            transform.Translate(velocity);
        }

        speed -= acceleration * Time.deltaTime;
    }
}
