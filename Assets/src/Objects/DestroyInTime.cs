using UnityEngine;
using System.Collections;


public class DestroyInTime : MonoBehaviour
{
    public float time;
    
    private void Start()
    {
        StartCoroutine(Destroy(time));
    }

    private IEnumerator Destroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

}
