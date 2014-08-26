using System;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour 
{

    public Text NumberStars, Bonus, Shots;

    public Image PanelShop;

    public Image[] SpeedStars;

    private Animator anim;

    private Canvas canvas;

    private void Awake()
    {
        anim = PanelShop.GetComponent<Animator>();
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    private void Update () 
    {

        canvas.enabled = GameManager.IsPlaying() || 
                         GameManager.Instance.States == GameManager.GameStates.Dead;

        ShowLabels();
    }
    
    /// <summary>
    /// Shows labels on screen
    /// </summary>
    private void ShowLabels()
    {
        NumberStars.text = GameManager.Instance.Skill.MiniStars + "/10";
        Bonus.text       = "Bonus: "+GameManager.Instance.Skill.Bonus;
        Shots.text       = "Shots: "+GameManager.Instance.Skill.CountShots;
      
        for(int i = 0; i < GameManager.Instance.Skill.SpeedStars; i++)
            SpeedStars[i].color = new Color32(38,179,237,255); 
    }
    
    /// <summary>
    /// (Seted to fired on inspector) Fired when shop button is cliked
    /// </summary>
    public void OpenShop()
    {
        if(!Input.GetKeyDown(KeyCode.Space))
            anim.SetBool("open", !anim.GetBool("open")); 
    }
    
    /// <summary>
    /// Fired when Speed button if cliked
    /// </summary>
    public void AddSpeed()
    {
        int Bonus = GameManager.Instance.Skill.Bonus;

        if(Bonus >= 50 && GameManager.Instance.Skill.SpeedStars < 4) {
            GameManager.Instance.Skill.Speed += 2;
            GameManager.Instance.Skill.SpeedStars++; 
            Debit(50);
        }
    }
    
    /// <summary>
    /// Fired when AddMunition button is cliked
    /// </summary>
    public void AddMunition()
    {
        int Bonus = GameManager.Instance.Skill.Bonus;

        if(Bonus >= 30) {
            GameManager.Instance.Skill.CountShots += 30;
            Debit(30);

        }
    }
    
    //TODO
    public void AddNewWeapon()
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Debit Bonus.
    /// </summary>
    /// <param name="value">Value.</param>
    private void Debit(int value)
    {
        GameManager.Instance.Skill.Bonus -= value; 
    }


}
