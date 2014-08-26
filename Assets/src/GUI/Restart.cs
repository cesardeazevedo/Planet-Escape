using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Show Label if dead
/// </summary>
public class Restart : MonoBehaviour {

    public static bool show;

    private Text tex;

    private void Awake()
    { 
       tex = GetComponent<Text>(); 
    }

    // Update is called once per frame
    private void Update () 
    {
        tex.enabled = show; 
    }
}
