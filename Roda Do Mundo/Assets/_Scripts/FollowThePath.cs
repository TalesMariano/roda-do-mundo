using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    public ListaPerguntas[] listas;

    public QuestionLoader[] cartasPerguntas;

    [SerializeField]
    private float moveSpeed = 1f;

    
    public int waypointIndex = 0;

    public bool moveAllowed = false;

    public UnityEvent landinSpace;
    public GameManager gameManager;

    public Button normalButton;
    public Button bonusButton;

	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	
	private void Update () {
        if (moveAllowed)
            Move();
	}

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
               // if (waypointIndex >= waypoints.Length - 1){
               //     print("coo");
                    
                //}
            }
        }
    }

    public void DotheStuff(){
        print("The Stuff");
        StartCoroutine(Stuff(1));
    }

    IEnumerator Stuff(float duration){
        AtualizaCartas();
        yield return new WaitForSeconds(duration);
        //landinSpace.Invoke();
        if(GameManager.lastNumber != 6){
            JogadaNormal();
        }else{
            JogadaBonus();
        }
    }

    void JogadaNormal(){
        gameManager.MostraCartas();
        normalButton.Select();
    }

    void JogadaBonus(){
        gameManager.MostraBonus();
    }

    void AtualizaCartas(){
        foreach(QuestionLoader cartas in cartasPerguntas){
            cartas.lista = listas[waypointIndex];
        }
    }
}
