using UnityEngine;

public struct ThirdPersonCharBackPack {
    private ThirdPersonChar tpChar;
    public ThirdPersonCharBackPack(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        DesactivateAllItems();
        WarningOnConsole();
        //TEST ========================================
        FillTheInventary();
    }
    private void FillTheInventary(){
        for (int i = 0; i < tpChar.GetBackPackTransform().childCount; i++){
            tpChar.GetBackPackData().AddToGotItems(i+1);
        }
    }
    public void Updater(){
        CheckItemSelection();
    }
    private void CheckItemSelection(){
        for (int i = 0; i < tpChar.GetBackPackData().GetItemsSelectInputs().Length; i++){
            if(Input.GetKey(tpChar.GetBackPackData().GetItemsSelectInputs()[i])){
                for (int j = 0; j < tpChar.GetBackPackTransform().childCount; j++){
                    if(j== i && tpChar.GetBackPackData().GetGotItems().Contains(j + 1)){
                        DesactivateAllItems();
                        tpChar.GetBackPackTransform().GetChild(j).gameObject.SetActive(true);
                        tpChar.GetBackPackData().SetSelectedBackPackItemIndex(j+1);
                        return;
                    }
                }
                return;
            }
        }
        if(Input.GetKey(tpChar.GetBackPackData().GetClearHandInput())){
            DesactivateAllItems();
        }
    }
    private void DesactivateAllItems(){
        foreach (Transform item in tpChar.GetBackPackTransform()){
            item.gameObject.SetActive(false);
            tpChar.GetBackPackData().SetSelectedBackPackItemIndex(0);
        }
    }
    private void WarningOnConsole(){
        if(tpChar.GetBackPackData().GetItemsSelectInputs().Length != tpChar.GetBackPackTransform().childCount){
            Debug.LogError("'Items Select Inputs' must have the same size as the 'backpack' child count");
        }
        if(tpChar.GetBackPackData().GetClearHandInput() == tpChar.GetBackPackData().GetItemsSelectInputs()[tpChar.GetBackPackData().GetItemsSelectInputs().Length-1]){
            Debug.LogError("Remove "+tpChar.GetBackPackData().GetClearHandInput()+" from 'ThirdPersonChar.itemsSelectInputs'. It's the 'clear hand' input.");
        }
    }
}
