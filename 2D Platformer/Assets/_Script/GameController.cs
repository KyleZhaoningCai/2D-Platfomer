using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    private static GameController _instance;
    public static GameController Instance { get { return _instance ?? (_instance = new GameController()); } }

    public int points { get; private set; }
    public int life { get; private set; }
    private string pointText;

    private GameController() {
        this.points = 0;
        this.life = 3;
    }

    // Use this for initialization
    void Start () {
        
        //UpdateScore();
    }
	
	public void AddScore (int newScoreValue)
    {
        points += newScoreValue;
        //UpdateScore();
    }

    public void ReduceLife()
    {
        this.life -= 1;
    }

	//void UpdateScore () {
 //       pointText = "Score: " + points;
	//}
}
