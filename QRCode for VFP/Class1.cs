using System.IO;
using System.Runtime.InteropServices;
using QRCoder;

namespace QRWrap
{
    [ComVisible(true)]
    [Guid("9c214e3d-969a-4778-ad5a-d141912642dc")]   // Tools > Create GUID
    [ProgId("QRWrap.Maker")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class Maker
    {
        public bool SavePng(string text, string file, int pixelsPerModule)
        {
            try
            {
                using (var gen = new QRCodeGenerator())
                using (var data = gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.M, false)) //true
                {
                    var png = new PngByteQRCode(data);
                    File.WriteAllBytes(file, png.GetGraphic(pixelsPerModule));
                    return true;
                }
            }
            catch { return false; }
        }
    }
}