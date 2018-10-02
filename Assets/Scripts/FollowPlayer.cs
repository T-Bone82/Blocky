using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private PlayerMovement movement;
    private Transform player;
    public Vector3 offset;
    public Vector3 offsetRotation;
    
    private void Awake()
    {
        // Getter for the player
        movement = GetComponent<PlayerMovement>();//TODO NullPointerException???
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
