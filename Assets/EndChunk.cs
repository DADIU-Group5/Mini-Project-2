using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndChunk : TerrainMovement {

    public override void Remove()
    {
        SceneManager.LoadScene(0);
    }
}
