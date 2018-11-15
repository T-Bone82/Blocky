using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Transform player;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private TextMeshProUGUI txtPoints;
    private TextMeshProUGUI txtHighScore;
    private Transform transformPoteau1;
    private Transform transformPoteau2;
    private GameObject endingMenu;

    private TrailRenderer boosterLeft;
    private TrailRenderer boosterCenter;
    private TrailRenderer boosterRight;

    private float resetTime = 0f;

    private bool theEnd = false;
    private bool waiting = false;
    private bool stoppedSpaceShip = false;

    void Start()
    {
        txtPoints = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        txtHighScore = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        transformPoteau1 = GameObject.Find("poteauFin1").GetComponent<Transform>();
        transformPoteau2 = GameObject.Find("poteauFin2").GetComponent<Transform>();
        endingMenu = Utilities.FindGameObject("EndingMenu");
        
        rb.freezeRotation = true;
        restart();
    }

    void FixedUpdate ()
    {
        if (!theEnd)
            KeepMoving();
        else
        {
            UpdateScores();
            ShowSuccessMenu();
        }
    }

    private void ShowSuccessMenu()
    {
        if (!stoppedSpaceShip)
        {
            stoppedSpaceShip = true;
            rb.velocity = new Vector3(0, 0, 20);
            resetTime = Time.fixedTime;
            setWaiting(true);
        }
        if (isWaiting())
        {
            if ((Time.fixedTime - resetTime) > 2)
                setWaiting(false);
        }
        else
        {
            endingMenu.SetActive(true);
        }
    }

    private void KeepMoving() {
        if (isWaiting())
        {
            if ((Time.fixedTime - resetTime) > 5)
                setWaiting(false);
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
            
            
        // Reading registered keys and searching for "d" or "a"
        if (Input.GetAxis("Horizontal") > 0)
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetAxis("Horizontal") < 0)
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        // Reset position and restart if player if falling off the cliff
        if (player.position.y < -10)
            restart();

        // Update score with an integer number
        txtPoints.text = ((int)player.position.z).ToString();
        
        // Is it the end?
        theEnd = isEnd();
    }

    private bool isEnd()
    {
        return 
            player.position.x > transformPoteau2.position.x 
            && player.position.x < transformPoteau1.position.x
            && player.position.z > transformPoteau1.position.z;
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
        setWaiting(true);
        resetTime = Time.fixedTime;
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(-3, 5f, 0f);
        UpdateScores();
    }

    public bool isWaiting() { return waiting; }
    public void setWaiting(bool value) { waiting = value; }

}
