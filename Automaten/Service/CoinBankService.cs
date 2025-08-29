using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Repository;

namespace Automaten.Service
{
    public class CoinBankService
    {
        // Implement CoinBankService methods here
        private ICoinBankRepo _coinBankInterface;
        public CoinBankService(ICoinBankRepo coinBankInterface)
        {
            _coinBankInterface = coinBankInterface;
        }

        public void AddCoin(int coin)
        {
            _coinBankInterface.AddCoin(coin);
        }
        public void RemoveCoin(int coin)
        {
            _coinBankInterface.RemoveCoin(coin);
        }
        public void CoinBankReport()
        {
            _coinBankInterface.CoinBankReport();
        }

    }
}
