using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

class ThirdPersonCharFadeIn : MonoBehaviour{
    private Image img;
    private float alpha = 1;
    [SerializeField]private float startDelay = .5f;
    [SerializeField]private float speed = .5f;
    [SerializeField]private UnityEvent onFadeIn = null;
    private void Awake(){ 
        img = GetComponent<Image>(); 
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
    }
    private void Update(){
        if(startDelay>0){
            startDelay -= Time.deltaTime;
            return;
        }
        if(alpha > 0.01f){
            alpha -= Time.deltaTime * speed;
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            return;
        }
        onFadeIn.Invoke();
        this.gameObject.SetActive(false);
    }
}
