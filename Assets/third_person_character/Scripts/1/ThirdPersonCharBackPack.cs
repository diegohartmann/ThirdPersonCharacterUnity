using UnityEngine;

public struct ThirdPersonCharBackPack {
    private ThirdPersonChar tpChar;
    public ThirdPersonCharBackPack(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        if(tpChar.numPadsInputs.Length > tpChar.backpack.childCount){
            Debug.LogWarning("Quantidade de inputs numéricos é MAIOR do que quantidade de ítens selecionáveis no inventário do personagem.");
        }
        else if(tpChar.numPadsInputs.Length < tpChar.backpack.childCount){
            Debug.LogWarning("Quantidade de inputs numéricos é MENOR do que quantidade de ítens selecionáveis no inventário do personagem.");
        }
    }
    public void Updater(){
        for (int i = 0; i < tpChar.numPadsInputs.Length; i++){
            if(Input.GetKey(tpChar.numPadsInputs[i])){
                foreach (Transform item in tpChar.backpack){
                    item.gameObject.SetActive(false);
                }
                tpChar.backpack.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
