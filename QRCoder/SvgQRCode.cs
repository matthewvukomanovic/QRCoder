using System;
using System.Drawing;
using System.Text;

namespace QRCoder
{
    public class SvgQRCode : AbstractQRCode<string>, IDisposable
    {
        public SvgQRCode(QRCodeData data) : base(data) { }


        public override string GetGraphic(int pixelsPerModule)
        {
            var viewBox = new Size(pixelsPerModule * this.QrCodeData.ModuleMatrix.Count, pixelsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, Color.Black, Color.White);
        }
        public string GetGraphic(int pixelsPerModule, Color darkColor, Color lightColor, bool drawQuietZones = true)
        {
            var viewBox = new Size(pixelsPerModule * this.QrCodeData.ModuleMatrix.Count, pixelsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkColor, lightColor, drawQuietZones);
        }

        public string GetGraphic(int pixelsPerModule, string darkColorHex, string lightColorHex, bool drawQuietZones = true)
        {
            var viewBox = new Size(pixelsPerModule * this.QrCodeData.ModuleMatrix.Count, pixelsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkColorHex, lightColorHex, drawQuietZones);
        }

        public string GetGraphic(Size viewBox, bool drawQuietZones = true)
        {
            return this.GetGraphic(viewBox, Color.Black, Color.White, drawQuietZones);
        }

        public string GetGraphic(Size viewBox, Color darkColor, Color lightColor, bool drawQuietZones = true)
        {
            return this.GetGraphic(viewBox, ColorTranslator.ToHtml(Color.FromArgb(darkColor.ToArgb())), ColorTranslator.ToHtml(Color.FromArgb(lightColor.ToArgb())), drawQuietZones);
        }

        public string GetGraphic(Size viewBox, string darkColorHex, string lightColorHex, bool drawQuietZones = true)
        {
            var svgFile = new StringBuilder(@"<svg version=""1.1"" baseProfile=""full"" width=""" + viewBox.Width + @""" height=""" + viewBox.Height + @""" xmlns=""http://www.w3.org/2000/svg"">");
            var unitsPerModule = (int)Math.Floor(Convert.ToDouble(Math.Min(viewBox.Width, viewBox.Height)) / this.QrCodeData.ModuleMatrix.Count);
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * unitsPerModule;
            var offset = drawQuietZones ? 0 : 4 * unitsPerModule;
            var drawableSize = size + offset;

            svgFile.AppendLine(@"<rect x=""" + (0 - offset) + @""" y=""" + (0 - offset) + @""" width=""" + (viewBox.Width - offset) + @""" height=""" + (viewBox.Height - offset) + @""" fill=""" + lightColorHex + @""" />");


            var modMatrix = QrCodeData.ModuleMatrix;
            var matrix = new Runs[modMatrix.Count][];

            for (int i = 0; i < modMatrix.Count; i++)
            {
                matrix[i] = new Runs[modMatrix.Count];
                for (int j = 0; j < modMatrix.Count; j++)
                {
                    matrix[i][j] = new Runs();
                }
            }
            ;


            var start = drawQuietZones ? 0 : 4;
            var end = drawQuietZones ? modMatrix.Count : modMatrix.Count - 4;


            for (int y = start; y < end; y++)
            {
                var yOffset = (y * unitsPerModule) - offset;
                for (int x = start; x < end; x++)
                {
                    var xOffset = (x * unitsPerModule) - offset;
                    var module = modMatrix[y][x];
                    var run = matrix[y][x];
                    run.Module = module;
                    run.SLeft = false;
                    run.SRight = false;
                    run.SUp = false;
                    run.SDown = false;

                    
                    if (y > start)
                    {
                        run.SUp = modMatrix[y - 1][x] == module;
                    }

                    if (y < end - 1)
                    {
                        run.SDown = modMatrix[y + 1][x] == module;
                    }

                    if (x > start)
                    {
                        run.SLeft = modMatrix[y][x - 1] == module;
                    }

                    if (x < end - 1)
                    {
                        run.SRight = modMatrix[y][x + 1] == module;
                    }

                    var count = 1;
                        for (int i = x + 1; i < end; i++)
                        {
                            if (modMatrix[y][i] == module)
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        run.YLength = count;

                        count = 1;
                        for (int i = y + 1; i < end; i++)
                        {
                            if (modMatrix[i][x] == module)
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        run.XLength = count;

                    //if (module)
                    { 
                        svgFile.AppendLine(@"<rect x=""" + xOffset + @""" y=""" + yOffset + @""" width=""" + (unitsPerModule * run.YLength)+ @""" height=""" + (unitsPerModule * run.XLength) + @""" fill=""" + (module ? darkColorHex : lightColorHex) + @""" />");
                    }

                        //svgFile.AppendLine(@"<text x=""" + (xOffset + (unitsPerModule / 2) )+ @""" y=""" + (yOffset + (unitsPerModule / 2)) + @""" width=""" + unitsPerModule + @""" height=""" + unitsPerModule + @""" fill=""black"" text-anchor=""middle"" font-size=""5px"">" + run.GetValues() + "</text>");
                    Console.Write(module ? "1" : " ");
                }
                Console.WriteLine();
            }


            //for (var y = 0; y < drawableSize; y = y + unitsPerModule)
            //{
            //    for (var x = 0; x < drawableSize; x = x + unitsPerModule)
            //    {
            //        var module = this.QrCodeData.ModuleMatrix[(y + unitsPerModule) / unitsPerModule - 1][(x + unitsPerModule) / unitsPerModule - 1];
            //        if (module)
            //        {
            //            svgFile.AppendLine(@"<rect x=""" + (x - offset) + @""" y=""" + (y - offset) + @""" width=""" + unitsPerModule + @""" height=""" + unitsPerModule + @""" fill=""" + (module ? darkColorHex : lightColorHex) + @""" />");
            //            //svgFile.AppendLine(@"<text x=""" + (x - offset) + @""" y=""" + (y - offset) + @""" width=""" + unitsPerModule + @""" height=""" + unitsPerModule + @""" fill=""black"" text-anchor=""middle"" font-size=""10px"">" + matrix[y][x], 1 </ text > ");
            //        }
            //        Console.Write(module ? "1" : " ");
            //    }
            //    Console.WriteLine();
            //}
            svgFile.Append(@"</svg>");
            return svgFile.ToString();
        }

        public void Dispose()
        {
            this.QrCodeData = null;
        }

        public class Runs
        {
            public bool Module = true;
            public int XLength = 0;
            public int YLength = 0;
            public bool Start = false;
            public bool Surrounded = false;
            public bool SLeft = false;
            public bool SRight = false;
            public bool SUp = false;
            public bool SDown = false;

            public string GetValues()
            {

                var requireDraw = false;


                StringBuilder sb = new StringBuilder();

                if (SLeft) sb.Append("L");
                if (SRight) sb.Append("R");
                if (SUp) sb.Append("U");
                if (SDown) sb.Append("D");


                switch (sb.ToString())
                {
                    case "":
                    case "RD":
                    case "R":
                    case "D":
                        requireDraw = true;
                        break;
                    case "L":
                    case "LR":
                    case "LU":
                    case "LD":
                    case "LRU":
                    case "LRD":
                    case "LUD":
                    case "LRUD":
                    case "UD":
                    case "RU":
                    case "RUD":
                        return "";
                    case "U":

                        requireDraw = false;
                        break;
                }

                if (requireDraw)
                {
                    return YLength + "," + XLength;
                }


                return sb.ToString();
            }
        }
    }
}
