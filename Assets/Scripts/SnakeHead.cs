using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{
    public float damageAmount;
    public GameObject slider;

    public int feverChargeCount;
    private int feverSpeed;
    private float feverMaxOffset;
    private float feverBodySpeed;

    public bool timerEnable;
    public float feverTime;
    private float startTime;
    private int crystalCount;

    private bool isDead;
    public GameObject deathPanek;
    private int eatenMan = 0;

    [SerializeField] private Text eaten;
    [SerializeField] private Text crystal;

    private void Start()
    {
        isDead = false;
        startTime = feverTime;
    }

    private void Update()
    {
        if (timerEnable == true)
        {
            slider.SetActive(true);
            feverTime -= Time.deltaTime;
            Debug.Log(feverTime);
            slider.GetComponent<Slider>().value = feverTime/5;

            
        }

        if (feverTime <= 0)
        {
            timerEnable = false;
            slider.SetActive(false);
            feverTime = startTime;
            FeverStop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Food>())
        {
            if (other.GetComponent<Renderer>().material.color == this.GetComponent<Renderer>().material.color)
            {
                this.GetComponentInParent<SnakeTail>().GrowSnake();
                eatenMan++;
                eaten.text = eatenMan.ToString();
            }

            else
            {
                if (timerEnable == false)
                {
                    GetDamage();
                }

                else
                {
                    this.GetComponentInParent<SnakeTail>().GrowSnake();
                    eatenMan++;
                    eaten.text = eatenMan.ToString();
                }
                
            }
            feverChargeCount = 0;
        }

        if (other.GetComponent<Bomb>())
        {
            if (timerEnable == false)
            {
                GetDamage();
            }

            else
            {
                this.GetComponentInParent<SnakeTail>().GrowSnake();
                eatenMan++;
                eaten.text = eatenMan.ToString();
            }
            feverChargeCount = 0;
        }

        if (other.GetComponent<Crystal>())
        {
            feverChargeCount++;
            crystalCount++;
            crystal.text = crystalCount.ToString();
            
            if (feverChargeCount >= 3)
            {
                feverChargeCount = 0;

                if(timerEnable == false)
                {
                    FeverStart();
                }
                timerEnable = true;
            }
        }
    }

    private void GetDamage()
    {
        this.GetComponentInParent<SnakeTail>().DestroyTail(damageAmount);

        eatenMan -= (int)damageAmount;

        if (eatenMan < 0)
        {
            eatenMan = 0;
        }

        eaten.text = eatenMan.ToString();
    }

    private void FeverStart()
    {
        feverSpeed = this.GetComponentInParent<SnakeMovement>().speed;
        feverMaxOffset = this.GetComponentInParent<SnakeMovement>().maxOffset;
        feverBodySpeed = this.GetComponentInParent<SnakeTail>().bodySpeed;

        this.GetComponentInParent<SnakeMovement>().speed = feverSpeed * 3;
        this.GetComponentInParent<SnakeMovement>().maxOffset = 0;
        this.GetComponentInParent<SnakeTail>().bodySpeed = feverBodySpeed * 3;
    }

    private void FeverStop()
    {
        this.GetComponentInParent<SnakeMovement>().speed = feverSpeed;
        this.GetComponentInParent<SnakeMovement>().maxOffset = feverMaxOffset;
        this.GetComponentInParent<SnakeTail>().bodySpeed = feverBodySpeed;
    }

    public void Death()
    {
        isDead = true;
        this.GetComponentInParent<SnakeMovement>().speed = 0;
        deathPanek.SetActive(true);
    }
}
