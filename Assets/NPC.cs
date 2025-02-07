using UnityEngine;
using Unity.Behavior;
public class NPC : MonoBehaviour
{

    [SerializeField]
    BehaviorGraphAgent _behaviorAgent;

    BlackboardVariable<string> _behaviorAgentMyString;
    BlackboardVariable<MyNewEventChannel> _behaviorAgentEventChannel;


    string _myString;

    private void Awake()
    {
        _behaviorAgent.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartNpc();

            Debug.Log("[c#]MyString at start: " + _behaviorAgentMyString.Value);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_behaviorAgentMyString != null)
            {
                _behaviorAgentMyString.Value = "value from c#";
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _behaviorAgent.BlackboardReference.GetVariableValue<string>("MyString", out var _myString);
            Debug.Log("[c#] my string = " + _myString);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _behaviorAgent.BlackboardReference.SetVariableValue<string>("MyString", "[c#] setvariablevalue   my string");
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
        if (_behaviorAgent.BlackboardReference.GetVariable("MyNewEventChannel", out _behaviorAgentEventChannel))
        {
            // ???? channel.Value.Event に登録してdisableでは、onvaluechangeから解除するの正しい？
            _behaviorAgentEventChannel.Value.Event += HandleEvent;
        }
    }

    void OnDisable()
    {
        if (_behaviorAgentMyString != null)
        {
            _behaviorAgentMyString.OnValueChanged -= OnMyStringValueChanged;
        }
        if (_behaviorAgentEventChannel != null)
        {
            Debug.Log("ondisable");
            // _behaviorAgentEventChannel.OnValueChanged-=HandleEvent;
            _behaviorAgentEventChannel.Value.Event -= HandleEvent;
        }
    }

    void StartNpc()
    {
        _behaviorAgent.enabled = true;
    }

    void OnMyStringValueChanged()
    {
        var newValue = _behaviorAgentMyString.Value;
        Debug.Log("[c#]OnMyStringValueChanged called: " + newValue);
    }


    void HandleEvent(string myText)
    {

        Debug.Log("[c#]my text:" + myText);
    }
}