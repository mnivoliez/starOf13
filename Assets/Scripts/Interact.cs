using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    bool interacting = false;
    BoxCollider2D interaction = null;

    // Use this for initialization
    void Start()
    {

    }

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {
        if (!interacting)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Vector2 charSize = GetComponent<Renderer>().bounds.size;
=======
					switch (GetComponent<MDirection> ().Get ()) {
					case 1:
						interaction.size = new Vector2 (charSize.x, 0.1f);
						interaction.offset = new Vector2 (0, charSize.y);
						break;
					case 2:
						interaction.size = new Vector2 (0.1f, 0.1f);
						interaction.offset = new Vector2 (charSize.x, charSize.y);
						break;
					case 3:
						interaction.size = new Vector2 (0.1f, charSize.y);
						interaction.offset = new Vector2 (charSize.x, 0);
						break;
					case 4:
						interaction.size = new Vector2 (0.1f, 0.1f);
						interaction.offset = new Vector2 (charSize.x, -charSize.y);
						break;
					case 5:
						interaction.size = new Vector2 (charSize.y, 0.1f);
						interaction.offset = new Vector2 (0, -charSize.y);
						break;
					case 6:
						interaction.size = new Vector2 (0.1f, 0.1f);
						interaction.offset = new Vector2 (-charSize.x, -charSize.y);
						break;
					case 7:
						interaction.size = new Vector2 (0.1f, charSize.y);
						interaction.offset = new Vector2 (-charSize.x, 0);
						break;
					case 8:
						interaction.size = new Vector2 (0.1f, 0.1f);
						interaction.offset = new Vector2 (-charSize.x, charSize.y);
						break;
					default:
						break;
					}
>>>>>>> add stuff

                interaction = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
                interaction.isTrigger = true;

                switch (GetComponent<Direction>().Get())
                {
                    case 1:
                        interaction.size = new Vector2(charSize.x, 0.1f);
                        interaction.offset = new Vector2(0, charSize.y);
                        break;
                    case 2:
                        interaction.size = new Vector2(0.1f, 0.1f);
                        interaction.offset = new Vector2(charSize.x, charSize.y);
                        break;
                    case 3:
                        interaction.size = new Vector2(0.1f, charSize.y);
                        interaction.offset = new Vector2(charSize.x, 0);
                        break;
                    case 4:
                        interaction.size = new Vector2(0.1f, 0.1f);
                        interaction.offset = new Vector2(charSize.x, -charSize.y);
                        break;
                    case 5:
                        interaction.size = new Vector2(charSize.y, 0.1f);
                        interaction.offset = new Vector2(0, -charSize.y);
                        break;
                    case 6:
                        interaction.size = new Vector2(0.1f, 0.1f);
                        interaction.offset = new Vector2(-charSize.x, -charSize.y);
                        break;
                    case 7:
                        interaction.size = new Vector2(0.1f, charSize.y);
                        interaction.offset = new Vector2(-charSize.x, 0);
                        break;
                    case 8:
                        interaction.size = new Vector2(0.1f, 0.1f);
                        interaction.offset = new Vector2(-charSize.x, charSize.y);
                        break;
                    default:
                        break;
                }

                interacting = true;
            }
        }
        else if (interaction != null)
        {
            Destroy(interaction);
            interacting = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable ii = other.GetComponent<IInteractable>();
        if (ii != null && interacting)
        {
            ii.Interact(this.gameObject);
            Destroy(interaction);
            interacting = false;
        }
    }
}
