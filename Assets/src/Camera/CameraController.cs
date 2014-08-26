using System;
using UnityEngine;

public class CameraController : Singleton<CameraController> 
{

    //Speed and Smooth intro
    private float Speed = 2;
    private float Smooth = 0.08f;

    private Vector3 StartPosition;

    private const float ZDistance = 35f;

    public static bool Intro;

    void Start()
    {
        StartPosition = new Vector3(transform.position.x,8.5f,ZDistance);
    }

    void Update()
    {        
        if(GameManager.Instance.States == GameManager.GameStates.Menu)
            return;

        if(Intro)
            BackPosition();
        
         if(GameManager.IsPlaying())
            FollowSpaceCraft();     

    }

    private void BackPosition()
    {
        float x = SmoothDamp(transform.position.x, StartPosition.x); 
        float y = SmoothDamp(transform.position.y, StartPosition.y); 
        
        transform.position = new Vector3(x,y,StartPosition.z); 

        if(Vector3.Distance(transform.position,StartPosition) < 0.5f){
            Intro = false;
          
            GameManager.Instance.States = GameManager.GameStates.Gaming;

        }
    }

    private void FollowSpaceCraft()
    {
        
        Transform planet = Planet.Instance.transform;

        float Vertical   = Input.GetAxis("Vertical");

        float angle = GameManager.Instance.Skill.Speed * (GameManager.IsPlaying()? Vertical : 0) * Time.deltaTime;

        Vector3 VectorPlanetDistance = new Vector3(planet.position.x,planet.position.y,planet.position.z);

        transform.RotateAround(VectorPlanetDistance, SpaceCraft.Instance.transform.up, angle);
        transform.LookAt(SpaceCraft.Instance.transform);
        transform.Rotate(new Vector3(0,SpaceCraft.Instance.transform.rotation.y,SpaceCraft.Instance.transform.rotation.z));
    }

    public void ResetPosition()
    {
        transform.position = StartPosition;
    }

    private float SmoothDamp(float from, float to)
    {
        return Mathf.SmoothDamp(from, to, ref Speed, Smooth);
    }

    public void DisableAnimation()
    {
        GetComponent<Animator>().enabled = false;
    }

    public void IntroFinish()
    {    
        Intro = true;
    }

}
