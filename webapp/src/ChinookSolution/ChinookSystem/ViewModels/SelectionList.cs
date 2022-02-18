#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class SelectionList
    {
        // Common class used to hold two values for use in select list scenario such as a drop-down list
        public int ValueId { get; set; }
        public string DisplayText { get; set; }
    }
}
