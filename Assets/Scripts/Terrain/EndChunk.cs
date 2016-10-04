using UnityEngine;
using System.Collections;

public class EndChunk : TerrainMovement {

    public override void Remove()
    {
        UIController.instance.ShowEndScreen();
        base.Remove();
    }
}
