using GamePurchasingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamePurchasingDemo.Abstract
{
    public interface ISalesService
    {
        public void AddSale(Sale sale);
        public void ApplySale(Sale sale, Game game);
    }
}
