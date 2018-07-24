using UnityEngine;
using System.Collections;
using UnityEditorInternal;
using System.Linq;
//Revised by Møllnitz on 24-07-18
public class GroundCheck : MonoBehaviour {
	//Dette script tjekker om objektet rører noget med et tag kaldet "Ground"
	//Scriptet sættes på empty object med trigger collider under player figur (så det tjekker om player står på noget Ground)

	//fortæller om figur er grounded
	public bool Grounded;

    public string GroundTag = "Ground";

	// Use this for initialization
	void Start () 
	{

        if (GameManager.instance.DebugMode)
        {
            Collider2D collider2Dref = gameObject.GetComponent<Collider2D>();
            if (collider2Dref == null)
            {
                Debug.LogWarning("GroundCheck: Collider2D Not Found!");

            }
            else if(collider2Dref.offset.y > 0f)
            {
                Debug.LogWarning("GroundCheck: Y offset above zero!");
            }

            if (!InternalEditorUtility.tags.Contains(GroundTag))
            {
                Debug.LogWarning("GroundCheck: Tag undefined, no tag available called: " + GroundTag);
            }
           

        }

		//figur sættes fra start til ikke at være grounded
		Grounded = false;
	}


	//Når Ground-objekt forlader triggerzone gøres figur ikke-grounded
    void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == GroundTag)
		{
			Grounded = false;
		}
	}

	//Når Ground-objekt befinder sig i triggerzone gøres figur grounded
    void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.tag == GroundTag)
		{
			Grounded = true;
		}
	}

    void OnTriggerEnter2D (Collider2D col)
    {

    }

	
}
