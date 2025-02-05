using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways]
public class WaypointContainer : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> _waypoints=new();

    public ReadOnlyCollection<Waypoint> Waypoints => _waypoints.AsReadOnly();

    [ExecuteAlways]
    void OnTransformChildrenChanged()
    {
        _waypoints.Clear();

        // 現在の全子オブジェクトをリストに追加する
        foreach (Transform child in transform)
        {
            var waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                _waypoints.Add(waypoint);
            }
        }
    }

}
