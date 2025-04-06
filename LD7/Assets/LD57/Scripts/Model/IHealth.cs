// Интерфейс отвечает за все действия, связанные со здоровьем
// кого-либо или чего-либо
interface IHealth
{
    public void TakeDamage(float damage);
    public float GetHealth();
}