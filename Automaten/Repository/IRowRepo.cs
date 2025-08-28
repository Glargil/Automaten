using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Models;

namespace Automaten.Repository
{
    public interface IRowRepo
    {
        void AddItem(Row row, Item itemToAdd);
        int GetItemPrice(Row row);
        Item EjectItem(Row row);
        string RowToString(Row row);
    }
}
