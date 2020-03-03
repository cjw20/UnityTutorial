using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 20f;
    Quaternion m_Rotation = Quaternion.identity;
    private Rigidbody body;
    Vector3 m_Movement;
    public GameEnding gameEnding;
    bool m_IsPlayerInRange;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");  //Gets input

        m_Movement.Set(horizontal, 0f, vertical);  //Updates movement vector
       // m_Movement.Normalize();
        body.AddForce(m_Movement * speed);
       
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
        body.MoveRotation(m_Rotation);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Intruder"))
        {
            m_IsPlayerInRange = true;
            gameEnding.CaughtPlayer();
        }   
        
    }
}
