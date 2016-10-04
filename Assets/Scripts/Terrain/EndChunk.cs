using UnityEngine;
using System.Collections;

public class EndChunk : TerrainMovement {

    public override void Remove()
    {
        AudioMaster.instance.PlayEvent("levelEnd");
        UIController.instance.ShowEndScreen();
        base.Remove();
    }
}
