using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameObject Prefab;

    public GameObject FinalScene;

    public enum GameStates {
        Menu,
        Animating,
        Gaming,
        Paused,
        Dead
    }

    public Skills Skill = new Skills();

    public GameStates States; 
    
    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {
        
        switch (States){

            case GameStates.Menu:
                return;

            case GameStates.Dead:
                Restart.show = true;
                RestartCraft();
                break;

            case GameStates.Gaming:
                
                Restart.show = false;
                //Set Pause
                PausedGame();

                FinalSceneCheck();
                break;
        }

    }
    
    /// <summary>
    /// Restarts the player.
    /// </summary>
    private void RestartCraft()
    {

        Destroy(SpaceCraft.Instance.gameObject);

        if(Input.GetKeyDown(KeyCode.Space)) {

            // Debug.Log(SpaceCraft.Instance.ToString()); 
            Instantiate(Prefab,Prefab.transform.position,Quaternion.identity);
            //Reset camera position
            CameraController.Instance.ResetPosition();
            //Set State for gaming
            SetGaming();
        } 

    }

    protected void SetGaming()
    {
        Instance.States = GameStates.Gaming;
    }

    /// <summary>
    /// Pauseds the game.
    /// </summary>
    private void PausedGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Instance.States = Instance.States != GameStates.Paused ? GameStates.Paused : GameStates.Gaming;

    }
    
    /// <summary>
    /// Finals the scene check.
    /// </summary>
    private void FinalSceneCheck()
    {
        //Check Count Stars or Cheat "B" + "R" Cheat
        if(Instance.Skill.MiniStars == 10 || Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.R)){

            FinalScene.particleSystem.startSize = 3;

            string descriptionText = Application.loadedLevelName != "Earth" ?
                "You are on the right way... (you finished)" : "Go Up, and go to another planet";

            Description.ShowDescription(descriptionText);
            if(Vector3.Distance(SpaceCraft.Instance.transform.position, FinalScene.transform.position) < 10){
                
                CameraController.Intro = true;
                ChangeScene();
            
            }
        }
    }

    public static bool IsPlaying()
    {
        return Instance.States == GameStates.Gaming;
    }

    protected void ChangeScene()
    {
        Application.LoadLevel("Mars");
    }
    
    protected void OnApplicationQuit()
    {
        Instance = null;
    }

}

