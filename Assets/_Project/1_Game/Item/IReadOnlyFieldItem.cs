namespace MB
{
    public interface IReadOnlyFieldItem
    {
        ItemID ID { get; }

        ItemCollider Collider { get; }

        ItemApperance Apperance { get; }
    }
}