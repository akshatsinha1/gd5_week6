using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    [SerializeField] float minSpeed, maxSpeed, minTorque, maxTorque, xRange, ySpawnPos;
    public int pointValue = 1;
    public int livesChange;
    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(Vector3.up * RandomNumberGenerator(minSpeed,maxSpeed), ForceMode.Impulse);


        targetRb.AddTorque(RandomNumberGenerator(minTorque, maxTorque), RandomNumberGenerator(minTorque, maxTorque), RandomNumberGenerator(minTorque, maxTorque), ForceMode.Impulse);


        transform.position = new Vector3(RandomNumberGenerator(-xRange, xRange), ySpawnPos, 0);
    }

    private void Update()
    {
        if (transform.position.y < -4 ) Destroy(gameObject);
    }

    float RandomNumberGenerator(float minRange, float maxRange)
    {
        return Random.Range(minRange, maxRange);
    }

    private void OnMouseDown()
    {
        gameManager.UpdateScore(pointValue, livesChange);

        if(gameManager.lives <= 0)
        { 
            gameManager.GameOver();
        }
        Destroy(gameObject);
        //update the score
        //update the lives
    }
}
