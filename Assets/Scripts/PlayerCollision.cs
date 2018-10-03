using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private PlayerMovement movement;
    //private float resetTime = 0f;
    //private bool restart = false;

    private void Awake()
    {
        // Getter for the player
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //delayedRecovery();
        if (collision.collider.tag == "ObstacleCube")
        {
            Debug.Log("You lose");
            //movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            //movement.enabled = false;
            //resetTime = Time.fixedTime;
            //restart = true;
            //movement.rb.velocity = Vector3.zero;
            //movement.rb.angularVelocity = Vector3.zero;
            movement.restart();
        }
        else  if (collision.collider.tag == "TheEnd")
        {
            Debug.Log("You win");
            movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            movement.enabled = false;
        }
    }

    /*private void delayedRecovery()
    {
        if (restart)
        {
            //if ((Time.fixedTime - resetTime) > 5)
            //{
               // resetTime = 0f;
                //restart = false;
               // movement.enabled = true;
                movement.restart();
            }
        }
    }*/
}
