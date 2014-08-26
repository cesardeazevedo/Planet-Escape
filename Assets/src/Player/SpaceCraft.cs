using UnityEngine;
using System.Collections;

public class SpaceCraft : Singleton<SpaceCraft>
{
    [HideInInspector]
    public Vector3 StartPosition;

    public GameObject explosion;
    public GameObject shots;
    public GameObject prefab;
    public GameObject SpaceCrash;
    private Transform arms;

    public AudioClip[] sounds;
    private AudioSource audioSource;

    private bool Alive;

    void Awake()
    {
        arms = transform.FindChild("Arms");     
        audioSource = GetComponent<AudioSource>();
    }
    
    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        //set start position  
        Instance.StartPosition = transform.position;
        Alive = true;

        audioSource.clip = sounds[1];
        audioSource.Play();
        audioSource.volume = 0f;

    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update()
    {

        if(!Alive || !GameManager.IsPlaying()) 
            return;

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical   = Input.GetAxis("Vertical");

        float angle = GameManager.Instance.Skill.Speed * Vertical * Time.deltaTime;

        audioSource.volume = angle * 20;

        transform.RotateAround(Planet.Instance.transform.position,
                               transform.up, angle);

        transform.Rotate(new Vector3(0,0,-Horizontal*5));

        Shot();

    }
    
    /// <summary>
    /// Die player
    /// </summary>
    public void Die()
    {

        Alive = false;
        InstantiateExplosion(); 
        GameManager.Instance.States = GameManager.GameStates.Dead; 

    }
    
    /// <summary>
    /// Enable player to shot
    /// </summary>
    private void Shot()
    {
        //Check Space Key and if have Shot Available
        if(Input.GetKeyDown(KeyCode.Space) && 
           GameManager.Instance.Skill.CountShots > 0) {

            GameObject Shot = (GameObject)Instantiate(shots, arms.transform.position, Quaternion.identity);

            GameManager.Instance.Skill.CountShots--;

            AudioManager.Instance.PlaySound(AudioManager.SoundEffect.Fire,0.3f);

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Check if player collied with Stars
        if(collider.gameObject.CompareTag("Star")) {

            Destroy(collider.gameObject);

            GameManager.Instance.Skill.MiniStars++;

            GameManager.Instance.Skill.Bonus += 30;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with steroids
        if(collision.gameObject.CompareTag("Steroids"))
        {
                     
            Instantiate(SpaceCrash, transform.position, Quaternion.identity);
            
            Destroy(collision.gameObject);    

            Die();
        }
    }
    
    //Put a Explosion on crash location
    private void InstantiateExplosion()
    {
        AudioManager.Instance.PlaySound(AudioManager.SoundEffect.Explosion);
        Instantiate(explosion,  transform.position, Quaternion.identity);
    }

}
