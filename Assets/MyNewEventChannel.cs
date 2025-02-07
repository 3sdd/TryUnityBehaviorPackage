using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/MyNewEventChannel")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "MyNewEventChannel", message: "[MyString] changed.", category: "Events", id: "496ddbe4f2205c2baafc14b5676a1025")]
public partial class MyNewEventChannel : EventChannelBase
{
    public delegate void MyNewEventChannelEventHandler(string MyString);
    public event MyNewEventChannelEventHandler Event; 

    public void SendEventMessage(string MyString)
    {
        Event?.Invoke(MyString);
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        BlackboardVariable<string> MyStringBlackboardVariable = messageData[0] as BlackboardVariable<string>;
        var MyString = MyStringBlackboardVariable != null ? MyStringBlackboardVariable.Value : default(string);

        Event?.Invoke(MyString);
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        MyNewEventChannelEventHandler del = (MyString) =>
        {
            BlackboardVariable<string> var0 = vars[0] as BlackboardVariable<string>;
            if(var0 != null)
                var0.Value = MyString;

            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as MyNewEventChannelEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as MyNewEventChannelEventHandler;
    }
}

