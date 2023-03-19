using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoDapper.Servicies.Init
{
    public interface IInitDataBaseServices
    {
        void InsertInitialData();
        void CleanDB();
    }
}
