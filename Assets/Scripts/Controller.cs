using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Rigidbody2D carRigidbody;
    public Rigidbody2D tire1;
    public Rigidbody2D tire2;
    public float movement;
    public float speed=20f;
    public float carTorque=10f;

    public GameObject FuelPanel;
    public Slider FuelSlider;
    public bool startbool=false;
    public bool ground;



    public Sprite GasOn;
    public Image  GasOff;
    public Sprite  GasOff2;
    public Sprite BreakeOn;
    public Image BreakeOff;
    public Sprite BreakeOff2;

    void Start()
    {
        FuelPanel.SetActive(false);
        startbool = true;
        FuelSlider.interactable = false;
        FuelSlider.maxValue = 100;
        FuelSlider.minValue = 0;
        FuelSlider.value = 99;
       

    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            GasOff.sprite = GasOn;
        }
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BreakeOff.sprite = BreakeOn;
        }
        if(Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.RightArrow))
        {
            GasOff.sprite = GasOff2;
        }
        if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.LeftArrow))
        {
            BreakeOff.sprite = BreakeOff2;
        }
       
        
        
        
        
        
        
        
        movement = Input.GetAxis("Horizontal");
        
        if (startbool == true)
        {
            FuelSlider.value =FuelSlider.value- 4* Time.deltaTime;
            if (FuelSlider.value < 30)
            {
                FuelPanel.SetActive(true);
            }

            if (FuelSlider.value > 30)
            {
                FuelPanel.SetActive(false);
            }
            
            if (FuelSlider.value <= 0)
            {
                Invoke("EndGame",3f);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fuel"))
        {
            FuelSlider.value = 100;
            Destroy(col.gameObject);
        }
       
    }

   


    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    void FixedUpdate()
    {
        if (FuelSlider.value > 0&& ground==true)
        {
            tire2.AddTorque(-movement*speed*Time.fixedDeltaTime);
            tire1.AddTorque(-movement*speed*Time.fixedDeltaTime);
            carRigidbody.AddTorque(-movement*carTorque*Time.fixedDeltaTime);
        }
      
    }
}
