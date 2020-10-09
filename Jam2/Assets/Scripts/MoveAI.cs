using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class MoveAI : MonoBehaviour
{
    public Transform[] waypoints;
    //public Vector3 goalPoint;
    UnityEngine.AI.NavMeshAgent agent;
    private float baseSpeed;
    private float angSpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        baseSpeed = agent.speed;
        angSpeed = agent.angularSpeed;
    }
    void Update()
    {
        if (TimeState.instance.minutesPerSecond==TimeState.instance.FastMPS)
        {
            agent.speed = baseSpeed * (TimeState.instance.FastMPS / TimeState.instance.BaseMPS);
            agent.angularSpeed = angSpeed * (TimeState.instance.FastMPS / TimeState.instance.BaseMPS);
        }
        else
        {
            agent.speed = baseSpeed;
            agent.angularSpeed = angSpeed;
        }
    }
    // Update is called once per frame
    public void SetDestination(int point)
    {
        agent.SetDestination(waypoints[point].position);
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        foreach (Transform point in waypoints)
        {
            Gizmos.DrawSphere(point.position, .2f);
        }
    }
}
