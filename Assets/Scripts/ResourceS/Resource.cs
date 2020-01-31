public abstract class Resource
{
    public int currentLevel { get; set; }

    public void UpgradeItem()
    {
        currentLevel++;
    }
}
