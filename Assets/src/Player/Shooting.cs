using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour 
{
    
    private Vector3 Direction;

    public GameObject Explosion;
    
    private float speed;

    private void Awake()
    {
        Transform Craft = SpaceCraft.Instance.transform;

        Direction = Craft.up;
        transform.rotation = Craft.rotation;
        
        //Speed Craft
        speed = 20.0f;
    }

    // Update is called once per frame
    private void Update () 
    {
        //Rotate Around Planet
        transform.RotateAround(Planet.Instance.transform.position,
                               Direction, speed * Time.deltaTime);
    }
   
    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.CompareTag("Steroids"))
            //Decrease Life of Steroid
            col.gameObject.GetComponent<Debris>().life -= 4;
             
        if(col.gameObject.CompareTag("Player"))  
            //Die if collide with player
            SpaceCraft.Instance.Die();
    
        //Destroy if collide with something
        Destroy(this.gameObject);

    }

}
