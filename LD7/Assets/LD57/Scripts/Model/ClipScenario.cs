using System.Collections.Generic;

public class ClipScenario
{
    Queue<Enemy> ClipOrder = new Queue<Enemy>();

    public void AddAction(Enemy enemy)
    {
        ClipOrder.Enqueue(enemy);
    }

    public Enemy GetNextAction()
    {
        if (ClipOrder.Count > 0) return ClipOrder.Dequeue();
        return null;
    }
}
