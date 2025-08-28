using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Repository
{
    public interface IPanelRepo
    {
        void InsertCoin(int coin);
        int CalcTotal();
    }
}
