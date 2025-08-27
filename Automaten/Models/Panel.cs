namespace Automaten.Models

{
    public class Panel
    {
        public List<Coins.Coins> InsertedCoins { get; set; } = new List<Coins.Coins>();

        public string InputRowSlot { get; set; }

        public int Change { get; set; }
        public int Profit { get; set; }

        public int CalcTotal()
        {
            int total = 0;
            foreach (var coin in InsertedCoins)
            {
                total += coin.Value;
            }
            return total;
        }


    }
}
