using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;  

    private void OnEnable() {
        gameEvent.addListener(this);
    }

    private void OnDisable() {
        gameEvent.removeListener(this);
    }

    public void OnEventRaised(){
         response.Invoke();
    }
}
