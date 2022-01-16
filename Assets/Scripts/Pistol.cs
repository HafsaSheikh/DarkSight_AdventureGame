using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : InventoryItemBase
{

   public override string Name 
    {
        get
        {
        return "Pistol";
        }
    }

    public override void OnUse()
    {
       base.OnUse();
        
    }
}
