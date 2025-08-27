namespace Automaten.Models

{
    public class Panel
    {
        public List<Coins.Coin> InsertedCoins { get; set; } = new List<Coins.Coin>();

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
