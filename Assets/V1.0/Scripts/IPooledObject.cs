namespace GameTemplate_UltimateSpaceShooterGamesMaker
{
	public interface IPooledObject
	{
		float Speed { get; set; }
		void OnObjectSpawn();
	}
}
