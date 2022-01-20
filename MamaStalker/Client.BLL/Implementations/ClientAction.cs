using Client.BLL.Abstractions;
using Common;
using System.Drawing;
using System.Drawing.Imaging;
using System;

namespace Client.BLL.Implementations
{
    public class ClientAction : IAction
    {
        private readonly Parser _parser;

        public ClientAction(Parser parser)
        {
            _parser = parser;
        }

        public void DoAction(byte[] data)
        {
            Bitmap screenshot = (Bitmap)_parser.ByteArrayToObject(data);
            string screenShotName = $"ScreenShots/{DateTime.Now.ToString()}";
            screenshot.Save(screenShotName, ImageFormat.Jpeg);
        }
    }
}
