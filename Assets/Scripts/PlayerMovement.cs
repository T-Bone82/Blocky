using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public Transform player;
    private bool notificationPublished = false;
    private bool resetPosition = false;
    private float resetTime = 0f;
    private bool pushedBack = false;

    // Update is called once per frame
    void FixedUpdate () {
        if (resetPosition && (Time.fixedTime - resetTime) > 5)
        {
            resetPosition = false;
            Debug.Log("set resetPosition to false");
        }

        if (resetPosition && !pushedBack)
        {
            rb.AddForce(0, 0, -2000 * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("BANG");
            pushedBack = true;
            this.enabled = false;
        }
        else if (!resetPosition)
        {
            //Debug.Log("Go for it JACK!");
            //this.enabled = true;
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
            Debug.Log("You fell in the hole");
            notificationPublished = true;
            resetPosition = true;
            resetTime = Time.fixedTime;
            transform.position = new Vector3(0, 5f, -5.76f);
        }
    }
}
