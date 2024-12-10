using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float turnSpeed = 20.0f;


    private Transform target;
    private int wavepointIndex = 0;

    public Transform enemy;

    public float basespeed = 5.0f;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * basespeed * Time.deltaTime, Space.World);

        if (dir != Vector3.zero) // 방향 벡터가 0이 아닐 때만 회전
        {
            Quaternion lookRotation = Quaternion.LookRotation(dir); // 이동 방향으로 회전
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); // 부드럽게 회전
        }

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }


    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
