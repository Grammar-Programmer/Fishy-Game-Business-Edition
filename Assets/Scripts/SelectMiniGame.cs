using UnityEngine;

public class SelectMiniGame : MonoBehaviour
{
    public Transform fishingRod;
    public GameObject border;
    public GameObject blueRectangle;
    public GameObject canvas;
    public int difficulty = 1;
    private float cursorSpeed; 
    private static float BORDERGAP = 100f;
    private bool movingRight = true;
    private bool hasWon;
    private RectTransform borderRectTranform;
    private bool isMoving = false;
    public FishingTrigger fishingTrigger;

    private float[] goalWidths = {0,200f, 150f, 100f ,75f, 50f };
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.W)) StartSelectMinigame();
        if(isMoving){
            if(Input.GetKey(KeyCode.Space)){
                isMoving = false;
                CheckSuccess();
            }
            else{
                CursorMovement();
            }
        }
    }
    public bool getHasWon(){
        return hasWon;
    }
    public void StartSelectMinigame(){
        borderRectTranform = border.GetComponent<RectTransform>();
        SetDifficultyParameteres();
        canvas.SetActive(true);        
        isMoving = true;
    }
    public void StartSelectMinigame(int level){
        SetDifficulty(level);
        StartSelectMinigame();
    }
    void CursorMovement() {
        // Move the fishing rod left to right and right to left
        if (movingRight){
            fishingRod.position += Vector3.right*cursorSpeed * Time.deltaTime ;
            if (fishingRod.localPosition.x >= borderRectTranform.rect.width / 2 - BORDERGAP ) movingRight=false;
        }
        else{
            fishingRod.position+= Vector3.left*cursorSpeed * Time.deltaTime;
            if (fishingRod.localPosition.x  <= -borderRectTranform.rect.width / 2 + BORDERGAP) movingRight=true;
        }
       
    }
    void SetDifficultyParameteres()
    {
        cursorSpeed = 400 + difficulty*100;
        SetBlueRectangle();
    }
    public void SetDifficulty(int newDifficulty){difficulty = newDifficulty;}
    void SetBlueRectangle(){
        
        float xScale = goalWidths[difficulty] / blueRectangle.GetComponent<RectTransform>().rect.width;
        blueRectangle.transform.localScale = new Vector3(xScale,1);

        System.Random random = new System.Random();
        float limitLeft = -(borderRectTranform.rect.width/2) + (BORDERGAP + goalWidths[difficulty]/2);
        float limitRight = borderRectTranform.rect.width/2 - (BORDERGAP + goalWidths[difficulty]/2);
        float randomxPos = (float)random.NextDouble()*(limitRight-limitLeft)  + limitLeft;

        blueRectangle.transform.localPosition = new Vector3(randomxPos,blueRectangle.transform.localPosition.y); 
    
    }
    void CheckSuccess(){   
        hasWon = Mathf.Abs(fishingRod.localPosition.x - blueRectangle.transform.localPosition.x) < goalWidths[difficulty] / 2;
        canvas.SetActive(false);
        fishingTrigger.selectMiniGameOver=true;
    }
}
