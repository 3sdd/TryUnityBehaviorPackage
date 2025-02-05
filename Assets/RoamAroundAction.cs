using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Roam Around", story: "[Agent] Roam Around using [WaypointContainer]", category: "Action", id: "d2f630619d5835deb055469fc2bb6c29")]
public partial class RoamAroundAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    [SerializeReference] public BlackboardVariable<WaypointContainer> WaypointContainer;

    Waypoint _targetWaypoint;
    protected override Status OnStart()
    {
        Debug.Log("[myaction]on start");
        Debug.Log(Agent.Value.name);
        SetRandomDestination();
        return Status.Running;
    }

    void SetRandomDestination()
    {
        var waypoints = WaypointContainer.Value.Waypoints;
        var waypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Count)];
        _targetWaypoint=waypoint;
        Agent.Value.SetDestination(waypoint.transform.position);
    }

    protected override Status OnUpdate()
    {
        Debug.Log("[myaction]on update");

        if (Vector3.Distance(Agent.Value.transform.position, Agent.Value.destination) <= Agent.Value.stoppingDistance)
        {
            Debug.Log("[myaction] waypoint reached");
            SetRandomDestination();

            
            return Status.Running;
        }


        return Status.Running;
    }

    protected override void OnEnd()
    {
        Debug.Log("[myaction]on end");

    }
}

