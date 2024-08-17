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
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;
            float distance = direction.magnitude;

            // If the object is far enough from the target, move towards it
            if (distance > stopDistance)
            {
                direction.Normalize();
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
