using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CancerVisualizer
{
    public class MyMouseCllick : UserControl
    {
        bool dragging = false;

        // ...

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (dragging)
            {
                // We've finished dragging, don't call MouseClick
                dragging = false;
                return;
            }

            // Not dragging, fire MouseClick
            base.OnMouseClick(e);
        }
    }
}
