using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model
{
    public class Filters
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        #region Bool props
        public bool UseItemCount { get; set; }
        public bool UseMinLimit { get; set; }
        public bool UseMaxLimit { get; set; }
        public bool UseName { get; set; }
        public bool UseSorting { get; set; }
        #endregion

        public int ItemCount { get; set; }
        public float MimLimit { get; set; }
        public float MaxLimit { get; set; }
        public string Name { get; set; }
        public string Sorting { get; set; }
    }
}
