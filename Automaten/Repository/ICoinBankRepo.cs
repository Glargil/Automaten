using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Repository
{
    public interface ICoinBankRepo
    {
        void AddCoin(int coin);
        void RemoveCoin(int coin);
        void CoinBankReport();
    }
}
