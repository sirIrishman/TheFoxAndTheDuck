using System.Windows.Forms;

namespace TheFoxAndTheDuck {
    public class DrawingPanel : Panel {
        public DrawingPanel() {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
