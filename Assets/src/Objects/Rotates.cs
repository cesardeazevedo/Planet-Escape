using UnityEngine;

public class Rotates : MonoBehaviour
{
    //Speed Rotation.
    public float speed;

    private void Update()
    {
        if(!GameManager.IsPlaying())
            return;
        //Rotate this Object
        transform.Rotate(0,speed * Time.deltaTime,0);
    }

}
