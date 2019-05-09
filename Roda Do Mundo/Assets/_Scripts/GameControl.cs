using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameControl : MonoBehaviour {

    //private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2; // jogadores

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;
    public UnityEvent goEvent;
    public SceneLoader sceneLoader;

    // Use this for initialization
    void Start () {

        //whoWinsTextShadow = GameObject.Find("WhoWinsText");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        //whoWinsTextShadow.gameObject.SetActive(false);
        //player1MoveText.gameObject.SetActive(true);
        //player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1.GetComponent<FollowThePath>().DotheStuff();
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
           // player2MoveText.gameObject.SetActive(false);
           // player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
           // whoWinsTextShadow.gameObject.SetActive(true);
          //  whoWinsTextShadow.GetComponent<Text>().text = "Player 1 Wins";
            if(gameOver == false){
                gameOver = true;
                GameOverFunction();
            }

            
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
           // whoWinsTextShadow.gameObject.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //player2MoveText.gameObject.SetActive(false);
           // whoWinsTextShadow.GetComponent<Text>().text = "Player 2 Wins";
           
            gameOver = true;
            GameOverFunction();
        }
    }

    public static void MovePlayer(int playerToMove) // Recebe qual player vai jogar
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    }

    public void GameOverFunction(){ // what happen on game over
        //goEvent.Invoke();
        //sceneLoader.MyLoadScene(0);
        StartCoroutine(GoEnd());
    }

    IEnumerator GoEnd()
    {
        
        yield return new WaitForSeconds(1);
        goEvent.Invoke();
    }
}
