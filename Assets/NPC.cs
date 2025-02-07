using UnityEngine;
using Unity.Behavior;
public class NPC : MonoBehaviour
{

    [SerializeField]
    BehaviorGraphAgent _behaviorAgent;

    BlackboardVariable<string> _behaviorAgentMyString;
    BlackboardVariable<string> _behaviorAgentEventChannel;

    private void Awake()
    {
        _behaviorAgent.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartNpc();

            Debug.Log("MyString at start: " + _behaviorAgentMyString.Value);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_behaviorAgentMyString != null)
            {
                _behaviorAgentMyString.Value = "value from c#";
            }
        }
    }

    void OnEnable()
    {
        //   if (m_Agent.BlackboardReference.GetVariable("StateEventChannel", out m_stateEventChannelBBV))
        //         m_stateEventChannelBBV.Value.Event += OnStateEvent;

        if (_behaviorAgent.BlackboardReference.GetVariable("MyString", out _behaviorAgentMyString))
        {
            _behaviorAgentMyString.OnValueChanged += OnMyStringValueChanged;
        }

    }

    void OnDisable()
    {
        if (_behaviorAgentMyString != null)
        {
            _behaviorAgentMyString.OnValueChanged -= OnMyStringValueChanged;
        }
    }

    void StartNpc()
    {
        _behaviorAgent.enabled = true;
    }

    void OnMyStringValueChanged()
    {
        var newValue = _behaviorAgentMyString.Value;
        Debug.Log("OnMyStringValueChanged called: " + newValue);
    }
}
