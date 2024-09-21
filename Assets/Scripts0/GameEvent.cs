 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>(); 

    //raise events through the different sigantures 

    public void raise(){
        for(int i = 0;i < listeners.Count; i++){
            listeners[i].OnEventRaised();
        }
    }
    //Manage the listeners
    public void addListener(GameEventListener listener){
        if(!listeners.Contains(listener)) listeners.Add(listener);
    }

    public void removeListener(GameEventListener listener){
        if(listeners.Contains(listener)) listeners.Remove(listener);
    }
} 
