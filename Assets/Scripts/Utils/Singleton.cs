using UnityEngine;


namespace Mini2.Utils
{
    /// <summary>
    /// Manager scripts should extend this class to implement a singleton pattern
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        public static T instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Debug.LogError("Duplicate singetons of type: " + typeof(T)+" Destroys this objects, make sure nothing else was on this object: "+gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
