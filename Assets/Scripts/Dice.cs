using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
   // public int whosTurn = 1;
    private bool coroutineAllowed = true;

    SpriteRenderer m_SpriteRenderer;
    Color newColor;
    Color _Color;
	// Use this for initialization
	private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
        newColor = new Color(150, 140, 140,255f);
        _Color = new Color(255, 255, 255,255f);
      //  SetDisabled();
    }

    public void SetEnabled(Transform t)
    {
        t.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1);
       // m_SpriteRenderer = t.GetComponent<SpriteRenderer>();
       // m_SpriteRenderer.color = _Color;
       // t.gameObject.GetComponent<BoxCollider>().enabled=true;
    }
    public void SetDisabled(Transform t)
    {
        t.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 1, 1);
       // m_SpriteRenderer = t.GetComponent<SpriteRenderer>();
        Debug.Log("_Dice ");
       
      //  t.gameObject.GetComponent<BoxCollider>().enabled=false;
    }
    public void OnAIRollDice()
    {
        StartCoroutine("RollTheDice");
    }
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed && GameControl.whosTurn==1)//whosTurn==1)
            StartCoroutine("RollTheDice");
    }
    private IEnumerator RollTheDiceAI()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

    }
        private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (GameControl.whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (GameControl.whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        GameControl.whosTurn *= -1;
        //GameControl.whosTurn = whosTurn;
        coroutineAllowed = true;
    }
}
