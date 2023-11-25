using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class PowerMinigame : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Image powerFill;


    private float powerAmt = 0;
    private bool isPowering = false;
    private float speed = 100.0f;
    private float accelaration;

    protected float result; // result from the minigame 0- failure ]0,1[- prop to add


    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.S)) StartPowerUp();
        if (Input.GetKey(KeyCode.M)) EndPowerUp();
        if (isPowering)
        {
            PowerAction();
        }
    }

    void PowerAction()
    {

        if (Input.GetKey(KeyCode.P))
        {
            powerAmt += speed * Time.deltaTime;
            powerFill.fillAmount = powerAmt / 100;
            powerFill.color = new Color(255,255,255,powerAmt/100 + 0.2f); 
            speed += accelaration;
            if (powerAmt >= 100f)
            {
                isPowering = false;
                result = 0;
                powerFill.color = Color.red;
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            isPowering = false;
            result = powerAmt >= 100f ? 0 : powerAmt;
        }
    }



    public void StartPowerUp()
    {
        //set default values

        Debug.Log("teste1");
        powerAmt = 0f;
        powerFill.fillAmount = 0;
        powerFill.color = Color.white;
        speed = 100.0f;

        //Uniform distribuiton
        accelaration = Random.Range(3f,23f);

        //start
        canvas.SetActive(true);
        isPowering = true;
    }



    public void EndPowerUp()
    {
        isPowering = false;
        canvas.SetActive(false);
    }
}
