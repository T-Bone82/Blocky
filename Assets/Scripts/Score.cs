using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private GameObject objPlayer;
    private PlayerMovement movement;
    private Transform player;
    private float score = 0f;
    private Text txtPoints;
    
    public float getScore() { return score; }
    public void setScore(float value) { score = value; }

    private void Awake()
    {
        txtPoints = GameObject.Find("Points").GetComponent<Text>();
        objPlayer = GameObject.Find("Player");

        if (objPlayer != null)
        {
            // Getting the component inside the Player object
            movement = objPlayer.GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (movement.getResetPosition())
        {
            txtPoints.text = "0";
        }
        if (movement != null) {
            if (movement.player.position.z > getScore())
            {
                setScore(movement.player.position.z);
            }
            txtPoints.text = ((int) getScore()).ToString();
        }
    }
}
