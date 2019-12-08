using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveAI : MonoBehaviour
{
	public Animator animator;
	public float speed = 1;

	public Vector2 autoPilotLeftPivot = Vector2.left;
	public Vector2 autoPilotRightPivot = Vector2.right;
	public Vector2 moveTest;
	public List<RuntimeAnimatorController> fastAnimator;
	public bool AutoPilot { get => autoPilot; set => autoPilot = value; }
	private bool autoPilot;

	public bool IsMove
	{
		get => isMove;
		private set
		{
			isMove = value;
			animator.SetBool("move", value);
		}
	}
	private bool isMove;

	private Vector2 wantPosition;
	private const float bit = 0.01f;
	private bool inverseX;

	private void Awake()
	{
		animator.runtimeAnimatorController = fastAnimator.GetRandomElement();
		StartCoroutine(AutoPilotCor());
	}

	public void MoveTo(Vector2 position)
	{
		var distance = Vector2.Distance(transform.position, position);
		if (distance > bit)
		{
			IsMove = true;
			wantPosition = position;
			if ((wantPosition.ToVector3() - transform.position).x < 0 ^ inverseX)
			{
				inverseX = !inverseX;
				transform.localScale = transform.localScale.Multiple(new Vector3(-1, 1, 1));
			}
		}
	}

    public void MoveTo(float x, float y)
    {
        MoveTo(new Vector2(x, y));
    }

    public Player player;
    public void SetUnit(Player player)
    {
        this.player = player;
        animator.runtimeAnimatorController = player.animator;
        MoveTo(5, -4);
    }

	private void Update()
	{
		if (!IsMove)
		{
			return;
		}

		var beforeDir = wantPosition.ToVector3() - transform.position;
		beforeDir = beforeDir.normalized;
		var afterPos = transform.position + (beforeDir * Time.deltaTime * speed);
		var afterDir = wantPosition.ToVector3() - afterPos;
		afterDir = afterDir.normalized;

		if (beforeDir != afterDir || Vector2.Distance(afterPos, wantPosition) < bit)
		{
			transform.position = wantPosition;
			IsMove = false;
		}
		else
		{
			transform.position = afterPos;
		}
	}

	private IEnumerator AutoPilotCor()
	{
		while(true)
		{
			if (AutoPilot  && !IsMove)
			{
				var randomPosition = RandomRange(autoPilotLeftPivot, autoPilotRightPivot);
				MoveTo(randomPosition);
			}
			yield return new WaitForSeconds(Random.Range(5, 10));
		}
	}

	private static Vector3 RandomRange(Vector3 start, Vector3 end)
	{
		return new Vector3(
			Random.Range(start.x, end.x),
			Random.Range(start.y, end.y),
			Random.Range(start.z, end.z));
	}
}
