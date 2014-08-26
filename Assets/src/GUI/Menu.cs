using UnityEngine;

/// <summary>
/// Show menu on start game
/// </summary>
public class Menu : MonoBehaviour
{
    
    private void Update()
    {
        
        if(GameManager.IsPlaying())
            Destroy(this.gameObject);

        if(Input.GetKeyDown(KeyCode.Space) && CameraController.Intro ) {
            
            CameraController.Instance.DisableAnimation();
            GameManager.Instance.States = GameManager.GameStates.Animating;
            
        }

    }

}
