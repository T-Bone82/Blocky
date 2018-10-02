using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject objPlayer;
    private PlayerMovement movement;
    private Transform player;
    public Vector3 offset;
    public Vector3 offsetRotation;
    
    private void Awake()
    {
        // Getter for the player
        objPlayer = GameObject.Find("Player");
        if (objPlayer != null)
        {
            // Getting the component inside the Player object
            movement = objPlayer.GetComponent<PlayerMovement>();
        }
        
        player = movement.player;

        // Doing a 10 degree rotation vertically
        transform.Rotate(10, 0, 0);
    }

    // Update is called once per frame
    void Update ()
    {
        // Camera is following the player
        transform.position = player.position + offset;
    }
}
