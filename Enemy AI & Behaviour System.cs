public interface IEnemyState
{
    void Update(Enemy enemy);
}

public class PatrolState : IEnemyState
{
    public void Update(Enemy enemy)
    {
        Console.WriteLine($"{enemy.Name} is patrolling.");

        if (enemy.PlayerDetected)
            enemy.ChangeState(new ChaseState());
    }
}

public class ChaseState : IEnemyState
{
    public void Update(Enemy enemy)
    {
        Console.WriteLine($"{enemy.Name} is chasing the player.");

        if (!enemy.PlayerDetected)
            enemy.ChangeState(new PatrolState());

        else if (enemy.DistanceToPlayer <= 2)
            enemy.ChangeState(new AttackState());
    }
}

public class AttackState : IEnemyState
{
    public void Update(Enemy enemy)
    {
        Console.WriteLine($"{enemy.Name} attacks the player!");

        if (enemy.DistanceToPlayer > 2)
            enemy.ChangeState(new ChaseState());
    }
}

public class Enemy
{
    public string Name { get; }
    public bool PlayerDetected { get; set; }
    public double DistanceToPlayer { get; set; }

    private IEnemyState currentState;

    public Enemy(string name)
    {
        Name = name;
        currentState = new PatrolState();
    }

    public void ChangeState(IEnemyState newState)
    {
        currentState = newState;
    }

    public void Update()
    {
        currentState.Update(this);
    }
}