using UnityEngine;

public class SearchLightDirection : MonoBehaviour
{
    private Light spotlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Vector3 directionToPlayer =
                player.transform.position - transform.position;
            float distance = directionToPlayer.magnitude;

            float angle = Vector3.Angle(
                transform.forward, directionToPlayer);

            if (distance <= spotlight.range &&
                angle <= spotlight.spotAngle / 2f)
            {
                PlayerLives playerLives = player.GetComponent<PlayerLives>();

                if (playerLives != null)
                {
                    playerLives.GetCaught();
                }
            }
        }
    }
}
