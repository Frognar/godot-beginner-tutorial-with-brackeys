using Godot;

namespace FirstGame;

public partial class Player : CharacterBody2D
{
	private const float speed = 130.0f;
	private const float jumpVelocity = -300.0f;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = jumpVelocity;
		}

		float direction = Input.GetAxis("move_left", "move_right");

		if (direction > 0f)
		{
			_animatedSprite.FlipH = false;
		}
		else if (direction < 0f)
		{
			_animatedSprite.FlipH = true;
		}
		
		if (direction != 0f)
		{
			velocity.X = direction * speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}