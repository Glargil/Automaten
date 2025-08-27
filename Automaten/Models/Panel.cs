namespace Automaten.Models

{
    public class Panel
    {
        public List<Coins.Coin> InsertedCoins { get; set; } = new List<Coins.Coin>();
        public string InputRowSlot { get; set; }
        public int Change { get; set; }
        public int Profit { get; set; }

        public Panel(string inputRowSlot, int change, int profit)
        { 
        
        }

        public void InsertCoin(int coin)
        {

            if (coin == 1)
            {
                Coins.Coin_One oneKr = new Coins.Coin_One();
                InsertedCoins.Add(oneKr);
            }
            else if (coin == 2)
            {
                Coins.Coin_Two twoKr = new Coins.Coin_Two();
                InsertedCoins.Add(twoKr);
            }
            else if (coin == 5)
            {
                Coins.Coin_Five fiveKr = new Coins.Coin_Five();
                InsertedCoins.Add(fiveKr);
            }
            else if (coin == 10)
            {
                Coins.Coin_Ten tenKr = new Coins.Coin_Ten();
                InsertedCoins.Add(tenKr);
            }
            else if (coin == 20)
            {
                Coins.Coin_Twenty twentyKr = new Coins.Coin_Twenty();
                InsertedCoins.Add(twentyKr);
            }

        }
        public int CalcTotal()
        {
            int total = 0;
            foreach (var coin in InsertedCoins)
            {
                total += coin.Value;
            }
            return total;
        }

        public int CalcChange(int price, int insertedCoins)
        {
            int change = insertedCoins - price;
            return change;
        }

    }
}
