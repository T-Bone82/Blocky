using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ObstacleCube")
        {
            Debug.Log("You lose");
            movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            movement.enabled = false;
            
        }
        if (collision.collider.tag == "TheEnd")
        {
            Debug.Log("You win");
            movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            movement.enabled = false;
        }
    }



}
