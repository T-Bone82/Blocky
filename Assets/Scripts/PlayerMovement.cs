using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Transform player;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool notificationPublished = false;
    private bool resetPosition = false;
    private float resetTime = 0f;
    
    // Update is called once per frame
    void FixedUpdate () {
        if (resetPosition)
        {
            if ((Time.fixedTime - resetTime) > 5)
            {
                resetPosition = false;
                notificationPublished = false;
            }        
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
            
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (player.position.y < -10 && !notificationPublished)
        {
            restart();
        }
    }

    public void restart()
    {
        notificationPublished = true;
        resetPosition = true;
        resetTime = Time.fixedTime;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = new Vector3(-3, 5f, -5.76f);
    }


}
