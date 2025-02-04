using UnityEngine;
using Unity.Behavior;
public class NPC : MonoBehaviour
{

    [SerializeField]
    BehaviorGraphAgent _behaviorAgent;

    private void Awake()
    {
        _behaviorAgent.enabled = false;
    }
    void Start()
    {
        //_behaviorAgent.Start();
        //_behaviorAgent.Restart();
        _behaviorAgent.enabled = true;
    }

}
