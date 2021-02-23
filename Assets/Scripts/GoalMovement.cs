
using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public Transform target;
    public int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si le gardien est arrivée a destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }
}
