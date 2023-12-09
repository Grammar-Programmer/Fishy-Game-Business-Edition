using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Threading;


public class PowerMinigame : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Image powerFill;
    public FishingTrigger fishingTrigger;
    private float powerAmt = 0;
    private bool isPowering = false;
    private float speed = 100.0f;
    private float accelaration;
    public float result; // result from the minigame 0- failure ]0,1[- prop to add


    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.S)) StartPowerUp();
        // if (Input.GetKey(KeyCode.M)) EndPowerUp();
        if (isPowering) PowerAction();
    }

    void PowerAction()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            powerAmt += speed * Time.deltaTime;
            powerFill.fillAmount = powerAmt / 100;
            powerFill.color = new Color(255, 255, 255, powerAmt / 100 + 0.2f);
            speed += accelaration;
            if (powerAmt >= 100f)
            {
                isPowering = false;
                result = 0;
                powerFill.color = Color.red;
                fishingTrigger.powerMiniGameOver = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPowering = false;
            result = powerAmt >= 100f ? 0 : powerAmt;
            fishingTrigger.powerMiniGameOver = true;
        }
    }
    public void StartPowerUp()
    {
        //set default values

        powerAmt = 0f;
        powerFill.fillAmount = 0;
        powerFill.color = Color.white;
        speed = 100.0f;
        //Uniform distribuiton
        accelaration = (float)RandomVariables.uniform(3, 8);

        //start
        canvas.SetActive(true);
        isPowering = true;
    }
    public void EndPowerUp()
    {
        isPowering = false;
        canvas.SetActive(false);
    }
    public bool isRunning()
    {
        return isPowering;
    }
}
