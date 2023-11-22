using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public event Action OnRandomDice;
    public event Action<int> OnGetNumber;
    public static EventManager instance;

    /*
     * Singleton initialisation
     * */
    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       DontDestroyOnLoad(gameObject);
    }

    /*
     * Dispatch OnRandomDice event
     */
    public void RandomDice() {
        OnRandomDice?.Invoke();
    }

    /*
    * Dispatch OnGetNumber event with the result number
    */
    public void GetNumber(int nb)
    {
        OnGetNumber?.Invoke(nb);
    }
    
  
}
