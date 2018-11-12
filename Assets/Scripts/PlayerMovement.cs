using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Transform player;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool notificationPublished = false;
    private bool resetPosition = false;
    private float resetTime = 0f;
    private TextMeshProUGUI txtPoints;
    private TextMeshProUGUI txtHighScore;

    private void Awake()
    {
        txtPoints = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        txtHighScore = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        restart();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // Verify if situation of restart
        if (getResetPosition())
        {
            if ((Time.fixedTime - resetTime) > 5)
            {
                // After 5 seconds let it be!
                setResetPosition(false);
                notificationPublished = false;
            }        
        }
        else
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Let advance the player
           
        // Reading registered keys and searching for "d" or "a"
        if (Input.GetAxis("Horizontal") > 0)
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetAxis("Horizontal") < 0)
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        
        // Reset position and restart if player if falling off the cliff
        if (player.position.y < -10 && !notificationPublished)
            restart();
        txtPoints.text = ((int)player.position.z).ToString();
    }

    private void UpdateScores()
    {
        int score = 0;
        int highScore = 0;
        int.TryParse(txtPoints.text, out score);
        if (int.TryParse(txtPoints.text, out score) && int.TryParse(txtHighScore.text, out highScore))
        {
            if (score > highScore)
                txtHighScore.text = txtPoints.text;
        }
    }

    public void restart()
    {
        notificationPublished = true;
        setResetPosition(true);
        resetTime = Time.fixedTime;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = new Vector3(-3, 5f, 0f);
        UpdateScores();
    }

    public bool getResetPosition() { return resetPosition; }
    public void setResetPosition(bool value) { resetPosition = value; }

}
