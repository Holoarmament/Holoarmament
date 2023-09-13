using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5.0f;
    public float detectionRadius = 5.0f;

    private void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            RotateTowards();
        }
    }

    private void RotateTowards()
    {
        // Calculate the direction from the agent to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Calculate the rotation that needs to be applied to face the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

        // Adjust the rotation to face the positive Z-axis (change the Euler angles)
        targetRotation *= Quaternion.Euler(0, 0, 90);

        // Smoothly interpolate the agent's rotation towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    private void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the Unity Editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
