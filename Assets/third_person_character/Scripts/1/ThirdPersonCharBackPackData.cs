using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="BackPackStatus", menuName="ThirdPersonCharObjs/ThirdPersonCharBackPackData", order=2)]
public class ThirdPersonCharBackPackData : ScriptableObject{
    
    private int selectedBackPackItemIndex = 0;
    public int GetSelectedBackPackItemIndex(){return this.selectedBackPackItemIndex;}
    public void SetSelectedBackPackItemIndex(int _value){this.selectedBackPackItemIndex = _value;}
    [SerializeField] private KeyCode clearHandInput = KeyCode.Alpha0;
    public KeyCode GetClearHandInput(){return this.clearHandInput;}
    [SerializeField] private KeyCode[] itemsSelectInputs = new KeyCode[] {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };
    public KeyCode[] GetItemsSelectInputs(){return this.itemsSelectInputs;}

    private List <int> gotItems = new List<int>();
    public List <int> GetGotItems(){return this.gotItems;}

    public void AddToGotItems(int _index){
        if(!this.gotItems.Contains(_index)){
            this.gotItems.Add(_index);
        }
    }
    public void RemoveFromGotItems(int _index){
        if(this.gotItems.Contains(_index)){
            this.gotItems.Remove(_index);
        }
    }

}
