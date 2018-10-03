using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private PlayerMovement movement;
    
    private void Awake()
    {
        // Getter for the player
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ObstacleCube")
        {
            Debug.Log("You lose");
            movement.restart();
        }
        else  if (collision.collider.tag == "TheEnd")
        {
            Debug.Log("You win");
            movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            movement.enabled = false;
        }
    }

}
