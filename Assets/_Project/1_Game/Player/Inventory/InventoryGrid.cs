namespace MB
{
    public class InventoryGrid
    {
        public int MaxRow { get; private set; }
        public int MaxColumn { get; private set; }
        public int Count => MaxRow * MaxColumn;

        public InventoryGrid(int maxRow, int maxColumn)
        {
            MaxRow = maxRow;
            MaxColumn = maxColumn;
        }

        public int ToIndex(int row, int column)
        {
            return column * MaxRow + row;
        }
    }
}