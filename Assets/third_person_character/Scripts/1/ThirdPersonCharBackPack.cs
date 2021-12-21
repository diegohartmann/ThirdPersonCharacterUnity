using UnityEngine;

public struct ThirdPersonCharBackPack {
    private ThirdPersonChar tpChar;
    public ThirdPersonCharBackPack(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        DesactivateAllItems();
        WarningOnConsole();
    }
    
    public void Updater(){
        CheckItemSelection();
    }
    private void CheckItemSelection(){
        for (int i = 0; i < tpChar.itemsSelectInputs.Length; i++){
            if(Input.GetKey(tpChar.itemsSelectInputs[i])){
                for (int j = 0; j < tpChar.backpack.childCount; j++){
                    if(j== i && tpChar.gotItems.Contains(j + 1)){
                        DesactivateAllItems();
                        tpChar.backpack.GetChild(j).gameObject.SetActive(true);
                        tpChar.selectedBackPackItem = j+1;
                        return;
                    }
                }
                return;
            }
        }
        if(Input.GetKey(tpChar.clearHandInput)){
            DesactivateAllItems();
        }
    }
    private void DesactivateAllItems(){
        foreach (Transform item in tpChar.backpack){
            item.gameObject.SetActive(false);
            tpChar.selectedBackPackItem = 0;
        }
    }
    private void WarningOnConsole(){
        if(tpChar.itemsSelectInputs.Length != tpChar.backpack.childCount){
            Debug.LogError("'Items Select Inputs' must have the same size as the 'backpack' child count");
        }
        if(tpChar.clearHandInput == tpChar.itemsSelectInputs[tpChar.itemsSelectInputs.Length-1]){
            Debug.LogError("Remove "+tpChar.clearHandInput+" from 'ThirdPersonChar.itemsSelectInputs'. It's the 'clear hand' input.");
        }
    }
}
