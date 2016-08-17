using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Direction currentDirection;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPosition;
    Vector3 endPos;
    float t;

    public Sprite northSprite;
    public Sprite southSprite;
    public Sprite eastSprite;
    public Sprite westSprite;

    public float walkSpeed = 3f;

	public bool isAllowedToMove;

	void Start()
	{
		isAllowedToMove = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && isAllowedToMove) 
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }


            if (input != Vector2.zero)
            {
                if (input.x  < 0 )
                {
                    currentDirection = Direction.West;
                }
                if (input.x > 0)
                {
                    currentDirection = Direction.East;
                }

                if (input.y < 0)
                {
                    currentDirection = Direction.South;
                }

                if (input.y > 0)
                {
                    currentDirection = Direction.North;
                }

                Sprite sprite = null;
                switch (currentDirection)
                {
                    case Direction.North:
                        sprite = northSprite;
                        break;
                    case Direction.South:
                    default:
                        sprite = southSprite;

                        break;
                    case Direction.East:
                        sprite = eastSprite;
                        break;
                    case Direction.West:
                        sprite = westSprite;
                        break;
                }

                gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

                StartCoroutine(Move(transform));
            }
        }


    }

    public IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPosition = entity.position;
        t = 0;

        endPos = new Vector3(startPosition.x + System.Math.Sign(input.x), startPosition.y + System.Math.Sign(input.y), startPosition.z);

        while(t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPosition, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

	

    public enum Direction
    {
        North = 0,
        South,
        East, 
        West
    }
}
