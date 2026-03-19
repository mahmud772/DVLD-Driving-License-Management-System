using Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper
{
    public static class clsUIHelper
    {

        public static Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix { Matrix33 = opacity }; // هنا نحدد الشفافية من 0 إلى 1
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                            0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
        
        // دالة تجعل حواف أي أداة مستديرة (A function that makes the corners of any control rounded)
        public static void CornerRadius(Control ctrl, int radius)
        {
            if (ctrl == null) return;

            // دالة داخلية لإعادة تطبيق القص بناءً على الحجم الحالي
            // Inner function to re-apply the clipping based on the current size
            void ApplyRegion()
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "IsAnimating") return;
                if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
                GraphicsPath path = new GraphicsPath();
                float curveSize = radius * 2F;
                RectangleF rect = new RectangleF(0, 0, ctrl.Width, ctrl.Height);

                path.StartFigure();
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                path.CloseFigure();

                // التخلص من المنطقة القديمة لتوفير الذاكرة
                // Dispose of the old region to save memory
                ctrl.Region?.Dispose();

                ctrl.Region = new Region(path);

                // المسار لم نعد نحتاجه بعد تعيين المنطقة
                path.Dispose();
            }

            // استدعاء أولي (Initial call)
            ApplyRegion();

            // ربط الحدث بشكل صحيح (Properly wire the event)
            ctrl.Resize += (s, e) => ApplyRegion();
        }

        
        

        
        public static void FitText(Label lbl , float MinSize)
        {
            // "We need to start with a large font and shrink it until it fits." 
            // (نحتاج أن نبدأ بخط كبير ونقوم بتصغيره حتى يناسب المساحة).

            float fontSize = 12.0f; // الحجم الأقصى للبدء (Maximum starting size)
            Font testFont;

            using (Graphics g = lbl.CreateGraphics())
            {
                while (fontSize > MinSize) // الحجم الأدنى للتوقف (Minimum size to stop)
                {
                    testFont = new Font(lbl.Font.FontFamily, fontSize, lbl.Font.Style);
                    SizeF textSize = g.MeasureString(lbl.Text, testFont);

                    // التحقق مما إذا كان النص يناسب عرض وارتفاع الليبل
                    // Checking if the text fits the label's width and height
                    if (textSize.Width < lbl.Width && textSize.Height < lbl.Height)
                    {
                        lbl.Font = testFont;
                        return;
                    }
                    fontSize -= 0.5f; // تقليل الحجم تدريجياً
                }
            }
        }


        public static void LoadImage(string imagePath, clsPersonEnums.enGendor gendor , PictureBox pbImage)
        {
            pbImage.Tag = imagePath;

            if (string.IsNullOrEmpty(imagePath))
            {
                _SetDefaultImage(gendor , pbImage);
                return;
            }


            if (!System.IO.File.Exists(imagePath))
            {
                _SetDefaultImage(gendor , pbImage);
                return;
            }

            try
            {

                using (var tempImage = System.Drawing.Image.FromFile(imagePath))
                {
                    pbImage.Image = new Bitmap(tempImage);
                }
            }
            catch
            {
                _SetDefaultImage(gendor , pbImage);
            }
        }
        
        private static void _SetDefaultImage(clsPersonEnums.enGendor gendor , PictureBox pbImage)
        {
            pbImage.Image = (gendor == clsPersonEnums.enGendor.Male) ?
                             Properties.Resources.MaleDefault : Properties.Resources.FemaleDefault;
        }
        

        public static void MakePictureBoxCircular(PictureBox pb)
        {
            if (pb.Width <= 0 || pb.Height <= 0) return;

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
                pb.Region = new Region(gp);
            }

            // لتحسين جودة عرض الصورة نفسها
            pb.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public static void MakeFramePictureBox(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float borderWidth = 2f;
            float inset = borderWidth / 2f;

            using (Pen pen = new Pen(ColorTranslator.FromHtml("#D1D8E0"), borderWidth))
            {
                e.Graphics.DrawEllipse(
                    pen,
                    inset,
                    inset,
                    pb.Width - borderWidth,
                    pb.Height - borderWidth
                );
            }
            
        }

     

        
    }

}
