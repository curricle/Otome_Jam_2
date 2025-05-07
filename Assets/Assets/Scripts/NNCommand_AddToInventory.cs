using UnityEngine;
using Naninovel;
using Naninovel.Commands;
using UnityEngine.Rendering;

[CommandAlias("AddToInventory")]
public class NNCommand_AddToInventory : Command
{

    [ParameterAlias("item")]
    public StringParameter item;

    public SO_Inventory inventory;

    public override UniTask Execute (AsyncToken asyncToken = default) {
        if(item == null) {
            Debug.Log("Nothing to add!");
        }
        else {
            Debug.Log($"We're adding {item} to the inventory");
        }  
        return UniTask.CompletedTask;
    }
}
