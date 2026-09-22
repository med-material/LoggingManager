using System.Collections.Generic;
using UnityEngine;

public class ContinuousLoggingExample : DataProvider
{
    [SerializeField]
    private GameObject camera;
    
    public override Dictionary<string, object> GetData()
    {
        Dictionary<string, object> data = new Dictionary<string, object>() {
            {"CameraPositionX", camera.transform.position.x},
            {"CameraPositionY", camera.transform.position.y},
            {"CameraPositionZ", camera.transform.position.z},
        };
        return data;
    }

}
