using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mini2.Utils;

public class Obstacles : Singleton<Obstacles> {

    List<Obstacle> allObstacles = new List<Obstacle>();

    /// <summary>
    /// Adds an obstacle to the list.
    /// </summary>
    /// <param name="ob"></param>
    public void AddObstacle(Obstacle ob)
    {
        allObstacles.Add(ob);
    }

    /// <summary>
    /// Gets the nearest obstacle, returns null, if there are no obstacles.
    /// </summary>
    /// <returns></returns>
    public Obstacle GetNearestObstacle()
    {
        if(allObstacles.Count > 0)
        {
            return allObstacles[0];
        }
        return null;
    }

    /// <summary>
    /// Get the Z-pos of the first obstacle.
    /// </summary>
    /// <returns></returns>
    public float GetZPosOfFirstObstacle()
    {
        if(allObstacles.Count > 0){
            if (allObstacles[0].transform.position.z > 0)
            {
                return allObstacles[0].transform.position.z;
            }
        }
        return Mathf.Infinity;
    }

    /// <summary>
    /// Get an obstacle closer than f away from 0 in z axis, returns null, if there is not one.
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public Obstacle GetNearestObstacleCloserThan(float f)
    {
        if(GetZPosOfFirstObstacle() > f)
        {
            return null;
        }
        else
        {
            return GetNearestObstacle();
        }
    }

    /// <summary>
    /// Removes the obstacle from the list.
    /// </summary>
    /// <param name="ob"></param>
    public void RemoveObstacle(Obstacle ob)
    {
        allObstacles.Remove(ob);
    }
}
