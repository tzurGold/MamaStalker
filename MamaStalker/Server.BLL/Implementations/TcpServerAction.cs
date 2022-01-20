using Common;
using Server.BLL.Abstraction;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;


namespace Server.BLL.Implementations
{
    public class TcpServerAction : IAction
    {

        private readonly int _refreshInterval;
        private readonly Parser _parser;

        public TcpServerAction(int refreshInterval, Parser parser)
        {
            _refreshInterval = refreshInterval;
            _parser = parser;
        }

        public void Execute(IConnectedClient connectedClient)
        {
            while (true)
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);

                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    connectedClient.Send(_parser.ObjectToByteArray(bitmap));
                }
                Thread.Sleep(_refreshInterval);
            }

        }
    }
}
