using UnityEngine;

public class Debris : MonoBehaviour
{

    private float Speed;

    private float RotateSpeed;

    public float life = 4; 
    
    public GameObject Explosion;
    
    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        Speed       = UnityEngine.Random.Range(0.5f,3);
        RotateSpeed = UnityEngine.Random.Range(1,3);
    }
    
    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {

        if(GameManager.Instance.States != GameManager.GameStates.Paused) 
            transform.Rotate(RotateSpeed,RotateSpeed,RotateSpeed);

        if(GameManager.IsPlaying()) {
            transform.RotateAround(Planet.Instance.transform.position, Vector3.up,    -Speed  * Time.deltaTime);
            transform.RotateAround(Planet.Instance.transform.position, Vector3.left,  Speed/2 * Time.deltaTime);
        }

        CheckDestroy();
    }
    
    /// <summary>
    /// Checks the destroy.
    /// </summary>
    private void CheckDestroy()
    {
        if(life < 0) {

            Instantiate(Explosion, transform.position, Quaternion.identity);
            
            AudioManager.Instance.PlaySound(AudioManager.SoundEffect.Explosion);
            
            Destroy(this.gameObject);

        }

    }


}
