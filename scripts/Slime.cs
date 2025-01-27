using Godot;

namespace FirstGame;

public partial class Slime : Node2D
{
	private const double speed = 60.0f;
	private int _direction = 1;
	private RayCast2D _rayCastRight;
	private RayCast2D _rayCastLeft;
	private AnimatedSprite2D _animatedSprite;
    
	public override void _Ready()
	{
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		if (_rayCastRight.IsColliding())
		{
			_direction = 1;
			_animatedSprite.FlipH = true;
		}

		if (_rayCastLeft.IsColliding())
		{
			_direction = -1;
			_animatedSprite.FlipH = false;
		}
		
		var position = Position;
		position -= new Vector2((float)(_direction * speed * delta), 0f);
		Position = position;
	}
}