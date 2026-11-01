using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public float protectionTime = 2f;

    private Vector3 spawnPosition;
    private Rigidbody rb;
    private float nextCatchTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPosition = rb.position;
    }

    public void GetCaught()
    {
        if (lives <= 0 || Time.time < nextCatchTime)
        {
            return;
        }

        lives--;
        nextCatchTime = Time.time + protectionTime;

        Debug.Log("Lives remaining: " + lives, gameObject);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (lives <= 0)
        {
            // Keep the cameras active while stopping this player.
            GetComponent<UnityEngine.InputSystem.PlayerInput>()
                .DeactivateInput();

            rb.isKinematic = true;
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;

            Debug.Log("Player eliminated!", gameObject);
            return;
        }

        rb.position = spawnPosition;
    }
}