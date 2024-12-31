using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IBillController
    {
        void UpdateBill(BillDetail bill, SelectedItem item); 
    }
}
