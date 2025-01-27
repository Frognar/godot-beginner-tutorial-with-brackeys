using Godot;

namespace FirstGame;

public partial class Coin : Area2D
{
	private GameManager _gameManager;

	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%GameManager");
	}

	private void _on_body_entered(Node2D body)
	{
		_gameManager.AddPoint();
		QueueFree();
	}
}