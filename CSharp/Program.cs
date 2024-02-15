using System;

using Vintasoft.Barcode;

namespace BarcodeGeneratorConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // register the evaluation license for VintaSoft Barcode .NET SDK
            Vintasoft.Barcode.BarcodeGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            try
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Usage: BarcodeGeneratorConsoleDemo outputfile.png BarcodeType BarcodeValue");
                    return;
                }
                try
                {
                    string fileName = args[0];
                    string barcodeType = args[1];
                    string barcodeValue = args[2];

#if NETCORE
                    // initialize Vintasoft.Barcode.SkiaSharp Assembly
                    Vintasoft.Barcode.SkiaSharpAssembly.Init();

                    // register custom encodings for QR and HanXin Code barcodes 
                    // (System.Text.Encoding.CodePages package)
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
#else
                    // initialize Vintasoft.Barcode.Gdi Assembly
                    Vintasoft.Barcode.GdiAssembly.Init();
#endif

                    // create barcode writer
                    BarcodeWriter writer = new BarcodeWriter();
                    writer.Settings.PixelFormat = BarcodeImagePixelFormat.Bgr24;

                    // set type of generating barcode
                    SetBarcodeType(writer.Settings, barcodeType);

                    // specify barcode value
                    writer.Settings.Value = barcodeValue;

                    // generate barcode as PNG file
                    writer.SaveBarcodeAsImage(fileName);

                    Console.WriteLine(string.Format("File '{0}' is created.", fileName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Error: {0}", ex.Message));
                }
            }
            finally
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Sets barcode type by name.
        /// </summary>
        /// <param name="settings">The barcode writer settings.</param>
        /// <param name="name">The name of barcode type.</param>
        private static void SetBarcodeType(WriterSettings settings, string name)
        {
            switch (name)
            {
                case "AustralianPost":
                    settings.Barcode = BarcodeType.AustralianPost;
                    break;
                case "JapanPost":
                    settings.Barcode = BarcodeType.JapanPost;
                    break;
                case "Aztec":
                    settings.Barcode = BarcodeType.Aztec;
                    break;
                case "Codabar":
                    settings.Barcode = BarcodeType.Codabar;
                    break;
                case "Code11":
                    settings.Barcode = BarcodeType.Code11;
                    break;
                case "Code128":
                    settings.Barcode = BarcodeType.Code128;
                    break;
                case "Code16K":
                    settings.Barcode = BarcodeType.Code16K;
                    break;
                case "Code39":
                    settings.Barcode = BarcodeType.Code39;
                    break;
                case "Code93":
                    settings.Barcode = BarcodeType.Code93;
                    break;
                case "DataMatrix":
                    settings.Barcode = BarcodeType.DataMatrix;
                    break;
                case "DotCode":
                    settings.Barcode = BarcodeType.DotCode;
                    break;
                case "DutchKIX":
                    settings.Barcode = BarcodeType.DutchKIX;
                    break;
                case "EAN13":
                    settings.Barcode = BarcodeType.EAN13;
                    break;
                case "EAN13Plus2":
                    settings.Barcode = BarcodeType.EAN13Plus2;
                    break;
                case "EAN13Plus5":
                    settings.Barcode = BarcodeType.EAN13Plus5;
                    break;
                case "EAN8":
                    settings.Barcode = BarcodeType.EAN8;
                    break;
                case "EAN8Plus2":
                    settings.Barcode = BarcodeType.EAN8Plus2;
                    break;
                case "EAN8Plus5":
                    settings.Barcode = BarcodeType.EAN8Plus5;
                    break;
                case "HanXinCode":
                    settings.Barcode = BarcodeType.HanXinCode;
                    break;
                case "IATA2of5":
                    settings.Barcode = BarcodeType.IATA2of5;
                    break;
                case "IntelligentMail":
                    settings.Barcode = BarcodeType.IntelligentMail;
                    break;
                case "Interleaved2of5":
                    settings.Barcode = BarcodeType.Interleaved2of5;
                    break;
                case "Mailmark4StateC":
                    settings.Barcode = BarcodeType.Mailmark4StateC;
                    break;
                case "Mailmark4StateL":
                    settings.Barcode = BarcodeType.Mailmark4StateL;
                    break;
                case "Matrix2of5":
                    settings.Barcode = BarcodeType.Matrix2of5;
                    break;
                case "MaxiCode":
                    settings.Barcode = BarcodeType.MaxiCode;
                    break;
                case "MicroPDF417":
                    settings.Barcode = BarcodeType.MicroPDF417;
                    break;
                case "MicroQR":
                    settings.Barcode = BarcodeType.MicroQR;
                    break;
                case "MSI":
                    settings.Barcode = BarcodeType.MSI;
                    break;
                case "PDF417":
                    settings.Barcode = BarcodeType.PDF417;
                    break;
                case "PDF417Compact":
                    settings.Barcode = BarcodeType.PDF417Compact;
                    break;
                case "PatchCode":
                    settings.Barcode = BarcodeType.PatchCode;
                    break;
                case "Pharmacode":
                    settings.Barcode = BarcodeType.Pharmacode;
                    break;
                case "Planet":
                    settings.Barcode = BarcodeType.Planet;
                    break;
                case "Postnet":
                    settings.Barcode = BarcodeType.Postnet;
                    break;
                case "QR":
                    settings.Barcode = BarcodeType.QR;
                    break;
                case "RoyalMail":
                    settings.Barcode = BarcodeType.RoyalMail;
                    break;
                case "RSS14":
                    settings.Barcode = BarcodeType.RSS14;
                    break;
                case "RSS14Stacked":
                    settings.Barcode = BarcodeType.RSS14Stacked;
                    break;
                case "RSSExpanded":
                    settings.Barcode = BarcodeType.RSSExpanded;
                    break;
                case "RSSExpandedStacked":
                    settings.Barcode = BarcodeType.RSSExpandedStacked;
                    break;
                case "RSSLimited":
                    settings.Barcode = BarcodeType.RSSLimited;
                    break;
                case "Standard2of5":
                    settings.Barcode = BarcodeType.Standard2of5;
                    break;
                case "Telepen":
                    settings.Barcode = BarcodeType.Telepen;
                    break;
                case "UPCA":
                    settings.Barcode = BarcodeType.UPCA;
                    break;
                case "UPCAPlus2":
                    settings.Barcode = BarcodeType.UPCAPlus2;
                    break;
                case "UPCAPlus5":
                    settings.Barcode = BarcodeType.UPCAPlus5;
                    break;
                case "UPCE":
                    settings.Barcode = BarcodeType.UPCE;
                    break;
                case "UPCEPlus2":
                    settings.Barcode = BarcodeType.UPCEPlus2;
                    break;
                case "UPCEPlus5":
                    settings.Barcode = BarcodeType.UPCEPlus5;
                    break;
                default:
                    throw new NotSupportedException(string.Format("Barcode type '{0}' is undefined.", name));
            }
        }
    }
}
