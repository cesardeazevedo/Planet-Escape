using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Display a Message on screen
/// </summary>
public class Description : MonoBehaviour {

    private static Text Message;

    public static bool Show = false;

    private void Awake()
    {
        Message = GetComponent<Text>();
        Show = false;
    }

    private void Update()
    {
        //Enabled message to show
        Message.enabled = Show; 
    } 

    /// <summary>
    /// Set a sessage to show
    /// </summary>
    /// <param name="msg">Message.</param>
    public static void ShowDescription(string msg)
    {
        Show = true;
        Message.text = msg;
    }

}
