using UnityEngine;
using UnityEngine.UI;

public class ShowIfPlaying : MonoBehaviour
{
    
    public bool IFNotPlaying;

    public bool ui;
    
    private Image img;

    private void Awake()
    {      
       img = ui ? GetComponent<Image>() : null; 
    }

    public void Update()
    {
        
        if(!ui)
            renderer.enabled = IFNotPlaying ? !GameManager.IsPlaying() : GameManager.IsPlaying();
        else
           img.enabled =   IFNotPlaying ? !GameManager.IsPlaying() : GameManager.IsPlaying();
        
    }
}
