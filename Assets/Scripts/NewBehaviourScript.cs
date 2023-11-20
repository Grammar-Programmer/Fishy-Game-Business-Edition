using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Image powerFill;
    private float powerAmt = 0;
    private bool isPowering = false;
    private float speed = 100.0f;
    private float accelaration;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S)) StartPowerUp();
        if(Input.GetKey(KeyCode.E)) EndPowerUp();
        if(isPowering){
            PowerAction();
        }
    }

    void PowerAction(){
        if(Input.GetKey(KeyCode.P)){
            powerAmt += speed * Time.deltaTime;
            powerFill.fillAmount = powerAmt/100;
            speed += accelaration;
            if(powerAmt >= 100f) {
                isPowering = false;
                powerFill.color = Color.red;
            }
        }
        if(Input.GetKeyUp(KeyCode.P)){
            isPowering = false;
        }
    }

    public void StartPowerUp(){
        powerAmt = 0f;
        powerFill.fillAmount = 0;
        powerFill.color = Color.white;
        speed = 100.0f;
        System.Random random = new System.Random();
        accelaration = (float)(random.NextDouble()*20) + 3;
        canvas.SetActive(true);
        isPowering = true;
    }

    public void EndPowerUp(){
        isPowering = false;
        canvas.SetActive(false);
        
    }
}