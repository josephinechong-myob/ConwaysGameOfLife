namespace ConwaysGameOfLife
{
    public class SeedDirector
    {
        public Seed MakeSeed(SeedBuilder seedBuilder, IGameConsole universeGameConsole)
        {
           // seedBuilder.CreateSeed(universeGameConsole);
            seedBuilder.SetSeedDimensions();
            seedBuilder.SetSeedCellState();

            return seedBuilder.GetSeed();
        }
    }
}