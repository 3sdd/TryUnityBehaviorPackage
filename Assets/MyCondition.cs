using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "MyCondition", story: "Toggle Condition", category: "Conditions", id: "2af37d8afc94214a66cf8d89cce04c57")]
public partial class MyCondition : Condition
{

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
