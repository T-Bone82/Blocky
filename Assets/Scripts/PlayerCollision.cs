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
            //GameObject crashAudio = GetObject("crashAudio");
            movement.restart();
        }
        else  if (collision.collider.tag == "TheEnd")
        {
            movement.rb.AddForce(0, 600 * Time.deltaTime, -500 * Time.deltaTime, ForceMode.Impulse);
            movement.enabled = false;
        }
    }

}
