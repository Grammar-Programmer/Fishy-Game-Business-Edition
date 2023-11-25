    public enum Level {
        Easy = 1,
        Medium = 3,
        Hard = 5
    }

    static class LevelMethods
{
    static Level[] levels = {Level.Easy, Level.Easy, Level.Medium, Level.Hard, Level.Hard, Level.Hard};

    public static Fish GetFishRarity(this Level s1)
    {
        switch (s1)
        {
            case Level.Easy:
                return GameManager.instance.inventoryManager.getCommumFish();
            case Level.Medium:
                return GameManager.instance.inventoryManager.getRareFish();
            default:
                return GameManager.instance.inventoryManager.getLegendaryFish();
        }
    }

    public static Level getLevel(int index) {
        return levels[index];
    }
}