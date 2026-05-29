using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WFPW05.Services
{
    internal class CAPTCHA
    {
        private Random _random = new Random();
        private const string CharPool = "ABCDEFGHJKLMNOPQRSTUVWXYZ"; //I специально пропущена тк трудночитаемая

        public byte[] CreateCaptchaBytes(int width, int height, out string text)
        {
                using (Bitmap bmp = new Bitmap(width, height))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    g.Clear(Color.White);

                    Noise(g, width, height);
                    text = new string(Enumerable.Range(0, 6)
                        .Select(_ => CharPool[_random.Next(CharPool.Length)]).ToArray());
                    
                    DrawWarpedText(g, text, width, height);
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
        }

        private void Noise(Graphics g, int width, int height)
        {
            //линии
            using (Pen greyPen = new Pen(Color.FromArgb(200, Color.Gray), 3))
            {
                for (int i = 0; i < 10; i++)
                {
                    g.DrawLine(greyPen, _random.Next(width), _random.Next(height), _random.Next(width), _random.Next(height));
                }
            }

            //точки
            using (SolidBrush greyBrush = new SolidBrush(Color.FromArgb(200, Color.Gray)))
            {
                for (int i = 0; i < 40; i++)
                {
                    float size = _random.Next(5, 12);
                    g.FillEllipse(greyBrush, _random.Next(width), _random.Next(height), size, size);
                }
            }
        }

        private void DrawWarpedText(Graphics g, string text, int width, int height) //искажённый текст
        {
            float fontSize = 28f;
            using (Font font = new Font("ComicSans", fontSize, FontStyle.Italic))
            using (Brush textBrush = new SolidBrush(Color.DimGray))
            {
                float totalWidth = text.Length * 30f;
                float startX = (width - totalWidth) / 2f;
                float centerY = height / 2f;

                for (int i = 0; i < text.Length; i++)
                {
                    float xPos = startX + (i * 30f);
                    float relativePos = (i - (text.Length / 2f)) / (text.Length / 2f);
                    float yOffset = (float)Math.Sin(relativePos * Math.PI) * 10f;

                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddString(text[i].ToString(), font.FontFamily, (int)font.Style, fontSize, new PointF(0, 0), StringFormat.GenericDefault);

                        Matrix m = new Matrix();
                        m.Translate(xPos, centerY + yOffset);

                        float angle = _random.Next(-30, 30);
                        m.RotateAt(angle, new PointF(0, 0));

                        float skewFactor = 1.0f + (relativePos * 0.5f);
                        m.Scale(1.2f, skewFactor);

                        g.MultiplyTransform(m);
                        g.FillPath(textBrush, path);
                        g.ResetTransform();
                    }
                }
            }
        }
    }
}
