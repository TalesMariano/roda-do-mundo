using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public  Button button;

    private Sprite[] diceSides;
    //private SpriteRenderer rend;

    int lastDice = 0;

    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    public Roulette russa;

    public GameManager gameManager;

    //rigging
    int maxDice = 7;

    bool foiBonus= false;
    int turnoAntesBonus = 4;


	// Use this for initialization
	private void Start () {
        //rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        //rend.sprite = diceSides[5];

        //button = GetComponent<Button>();
	}

    private void OnMouseDown()
    {
        ClickStop();
    }

    void Update(){
        /*
        if(Input.GetKeyDown(KeyCode.Space) && button.interactable){

            ClickStop();
        } */
    }

    public void ClickStop(){
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        russa.Move(); // Começa a girar a roleta
         // Previne multiplas coorotinas
        int randomDiceSide = 0;
        int moveSpaces;
                                                    //for (int i = 0; i <= 1; i++)
                                                    //{

        randomDiceSide = Random.Range(0, maxDice);



        if(!foiBonus){
            turnoAntesBonus--;

            if(turnoAntesBonus <=0)
            randomDiceSide = 6;
        }
        if(randomDiceSide == 6)
            foiBonus = true;
        
        GameManager.lastNumber = randomDiceSide;

        print("Cor Rodada: "+(randomDiceSide - 3));

        russa.RecebeNum(randomDiceSide);

        if(randomDiceSide != 6){

            moveSpaces = (randomDiceSide + lastDice)%3;

            //rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
            //}

            print("Move Spaces: "+(moveSpaces+1));

            print("LastDice: " + lastDice + ", this LastDice: " +  Mathf.Abs(randomDiceSide - 2));
            GameControl.diceSideThrown = moveSpaces + 1;
            lastDice = Mathf.Abs((randomDiceSide%3) - 2);
        }else{
            maxDice = 6;
            yield return new WaitForSeconds(1.1f);
            gameManager.PerguntaBonus();

        }
        
        

        //if (whosTurn == 1)
        //{
            
        //} else if (whosTurn == -1)
        //{
        //    GameControl.MovePlayer(2);
        //}
        //whosTurn *= -1;



        
    }

    public void AllowCo(){
        coroutineAllowed = true;
    }
}
