using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerVisualizer
{
    class ExperimentHistory
    {
        public List<int> predicted { get; set; }
        public List<int> ground_truths { get; set; }
        public List<int[]> coords { get; set; }
        public List<int> flags { get; set; }
        public ExperimentHistory()
        {
            predicted = new List<int>();
            ground_truths = new List<int>();
            coords = new List<int[]>();
            flags = new List<int>();
        }
    }
}
