using UnityEngine;
using System.Collections;

public class PlayerMovementSmooth : MonoBehaviour {
	//Dette script lader spilleren styre figurens bevægelser med piletaster eller med adsw

	//MoveSpeed styrer hastigheden af spillerens bevægelse
	[Header("Default: 5")]
    [Range(2f,10f)]
	public float moveSpeed = 5;

	//her kan man vælge om det skal være muligt at bevæge sig op/ned og højre/venstre
    public bool X;
    public bool Y;

	//værdi for hvor meget x og y skal ændres ved hver frame
	private float deltaX;
	private float deltaY;

	private Rigidbody2D rb2d;

    private GroundCheck groundCheck;
	

	void Start ()
	{
        groundCheck = GetComponentInChildren<GroundCheck>();
        rb2d = GetComponent<Rigidbody2D>();

		if (GameManager.instance.DebugMode)
		{
			if (!X && !Y)
			{
				Debug.LogWarning("Neither X or Y enabled, enable one or both.");
			}
			if (!this.CheckForComponent<Rigidbody2D>())
			{
				Debug.LogWarning("Rigidbody Not Found On Player");
			}
		}

	}

	// Update is called once per frame
	void Update () {

		//Hvis right/left bevægelse er tilvalgt beregnes deltaX. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (X)
		{
			deltaX = moveSpeed * Input.GetAxis("Horizontal");

			//Her ændres objektets hastighed på x-akse. Y-værdi fastholdes.
            if(groundCheck.Grounded)
            {
                rb2d.velocity = new Vector2(deltaX, rb2d.velocity.y);
            }
			//Hvis du er i luften og bevæger dig hurtigere end din movespeed kan du ikke accelere yderligere.
			// Eller hvis du bevæger dig imod den retning du holder på knapperne.
            else if(rb2d.velocity.x > -moveSpeed + 0.1f && rb2d.velocity.x < moveSpeed - 0.1f || Mathf.Sign(deltaX) != Mathf.Sign(rb2d.velocity.x))
            {
				if (deltaX != 0f && rb2d.velocity.magnitude > 0.5f)
				{
					rb2d.velocity = new Vector2( rb2d.velocity.x *0.95f, rb2d.velocity.y);
				}
				rb2d.AddForce(new Vector2(deltaX, 0f), ForceMode2D.Force);
            }
			
		}

		//Hvis right/left bevægelse er tilvalgt beregnes deltaY. Input.GetAxis er en Unity-feature, som giver bløde bevægelser.
		if (Y)
		{
			deltaY = moveSpeed * Input.GetAxis("Vertical");

			//Her ændres objektets hastighed på y-akse. X-værdi fastholdes.
			rb2d.velocity = new Vector2 (rb2d.velocity.x, deltaY);
		}


		

	}

	public void Freeze()
	{
		rb2d.velocity = Vector2.zero;
		rb2d.gravityScale = 0f;
	}

	public void UnFreeze()
	{
		rb2d.gravityScale = 1f;
	}
	
}