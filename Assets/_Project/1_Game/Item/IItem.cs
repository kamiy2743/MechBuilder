namespace MB
{
    public interface IItem : IRaycastReceiver
    {
        string Name { get; }
    }
}