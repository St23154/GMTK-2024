using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // The target the object should follow (e.g., the player)
    public Transform target;

    // Speed at which the object should follow the target
    public float speed = 5f;

    // Distance threshold to stop following when close enough
    public float stopDistance = 0.5f;

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target only on the X-axis
            float directionX = target.position.x - transform.position.x;
            float distance = Mathf.Abs(directionX);

            // If the object is far enough from the target on the X-axis, move towards it
            if (distance > stopDistance)
            {
                // Normalize direction on X-axis
                directionX = Mathf.Sign(directionX);

                // Move the object towards the target on the X-axis
                transform.position += new Vector3(directionX * speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
