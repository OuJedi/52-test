using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public float speed = 1f;
    public float endAnimTime = 1.5f;

    private float rollDelay = 1f;
    private float offsetAngle = 0f;
    private float angleX = .4f;
    private float angleY = 1.2f;
    private float angleZ = 1.2f;
    private bool isBusy = false;
    private bool rotateAccess = false;
    void Start()
    {
    /*
     * Get the parent rotation x angle for correcting the children destination angle
     */
        offsetAngle = transform.parent.rotation.eulerAngles.x;

        EventManager.instance.OnRandomDice += RotateDice;

    }

    /*
     * Rotate the dice + get random face 
     */
    private void RotateDice()
    {
        if (isBusy)
        {
            return;
        }

        isBusy = true;
        rotateAccess = true;

        int id = (int) Random.Range(1f, 6.99f);

        Tween tween = transform.DORotate(IdToAngles(id), endAnimTime);
        tween.onComplete = () => {
            if(id == 6)
            {
                transform.DOShakePosition(1.5f,2f);
            }
            EventManager.instance.GetNumber(id);
            isBusy = false;            
        };
        tween.OnStart(() => {
            rotateAccess = false;
        });
        tween.SetDelay(rollDelay); // Time before stopping rotate the dice
        tween.SetEase(Ease.OutBack);       
    }


    /*
     * Get Euler Angles from face value
     */
    private Vector3 IdToAngles(int id)
    {
        switch (id)
        {
            case 1: return new Vector3(offsetAngle, 0f, 0f);
            case 2: return new Vector3(0f, -90f, -offsetAngle);
            case 3: return new Vector3(90f + offsetAngle, 0f, 0f);
            case 4: return new Vector3(-90f + offsetAngle, 0f, 0f);
            case 5: return new Vector3(0f, 90f, offsetAngle);
            case 6: return new Vector3(180f + offsetAngle, 0f, 0f);
        }
        return new Vector3();
    }



    private void OnDisable()
    {
        EventManager.instance.OnRandomDice -= RotateDice;
    }


    private void Update()
    {
        if (rotateAccess)
        {
            transform.Rotate(new Vector3(angleX*speed, angleY * speed, angleZ * speed));            
        }
        
    }
}
