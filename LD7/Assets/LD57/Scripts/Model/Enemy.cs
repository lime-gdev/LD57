using UnityEngine;

public class Enemy
{
    public float SpawnDelay { get; private set; }
    public Vector3 SpawnPoint { get; private set; }

    public Enemy(float spawnDelay, Vector3 spawnPoint)
    {
        SpawnDelay = spawnDelay;
        SpawnPoint = spawnPoint;
    }
}

public class Crockodilo : Enemy
{
    public float BombardiniDelay { get; private set; }
    public int Direction { get; private set; }

    public Crockodilo(float spawnDelay, Vector3 spawnPoint, float bombardiniDelay, int direction) : base(spawnDelay, spawnPoint)
    {
        BombardiniDelay = bombardiniDelay;
        Direction = direction;
    }
}
public class Frogo : Enemy
{
    public float Speed { get; private set; }
    public int Direction { get; private set; }

    public Frogo(float spawnDelay, Vector3 spawnPoint, float speed, int direction) : base(spawnDelay, spawnPoint)
    {
        Speed = speed;
        Direction = direction;
    }
}
