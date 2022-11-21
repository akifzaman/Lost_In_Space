public interface IPooledObject
{
    float Speed { get; set; }
    float Boundary { get; set; }
    void OnObjectSpawn();
}
