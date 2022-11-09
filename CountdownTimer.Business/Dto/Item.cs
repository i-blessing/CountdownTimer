using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Business.Dto
{
    public class Item
    {
        /// <summary>
        /// Id of the item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Quantity of the item
        /// </summary>
        public int Count { get; set; }
    }
}
