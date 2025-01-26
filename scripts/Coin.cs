using Godot;

namespace FirstGame;

public partial class Coin : Area2D
{
	private void _on_body_entered(Node2D body)
	{
		Godot.GD.Print("+1 coin!");
		QueueFree();
	}
}