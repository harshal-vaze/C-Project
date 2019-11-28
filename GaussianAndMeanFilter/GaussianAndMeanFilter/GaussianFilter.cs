using LearningFoundation;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GaussianAndMeanFilter
{

    /// <summary>
    /// Main class for the Gaussian Filter algorithm using IPipeline
    /// </summary>    
    public class GaussianFilter : IPipelineModule<double[,,], double[,,]>
    {

        /// <summary>
        /// Gaussian Filter Kernel of 3x3
        /// </summary>
        public static double[,] GaussianBlur3x3
        {
            get
            {
                return new double [,]
                { { 1, 2, 1, },
                  { 2, 4, 2, },
                  { 1, 2, 1, }, };
            }
        }
     
        /// <summary>
        /// Gaussian Filter Kernel of 5x5
        /// </summary>
        public static double[,] GaussianBlur5x5
        {
            get
            {
                return new double[,]
                { { 2, 04, 05, 04, 2 },
                  { 4, 09, 12, 09, 4 },
                  { 5, 12, 15, 12, 5 },
                  { 4, 09, 12, 09, 4 },
                  { 2, 04, 05, 04, 2 }, };
            }
        }

        /// <summary>
        /// Method of Interface IPipeline
        /// </summary>
        /// <param name="data">this is the double data coming from UnitTest</param>
        /// <param name="ctx">this define the Interface IContext for Data descriptor</param>
        /// <returns></returns>        
        public double[,,] Run(double[,,] data, IContext ctx)
        {
            return GaussianConvolutionFilter(data, GaussianBlur5x5, 1, 0);
        }

        /// <summary>
        /// Taking the image data in double array and applying kernel convoution to image data(pixel value)
        /// and returing double data again after necessary conversion.
        /// </summary>
        /// <param name="data"> data coming from Run method of Ipipeline Interface</param>
        /// <param name="GaussianBlur5x5">the Gaussian Filter Kernel of Matrix 5x5</param>
        /// <param name="factor">multiplying factor for adjusting RGB contrast</param>
        /// <param name="bias">addition factor for adjusting RGB contrast</param>
        /// <returns></returns>
        public double[,,] GaussianConvolutionFilter(double[,,] data, double[,] GaussianBlur5x5, double factor = 1, int bias = 0)
        {        
            Bitmap bitmap = new Bitmap(data.GetLength(0), data.GetLength(1));

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    int r = (int)data[i, j, 0];
                    int g = (int)data[i, j, 1];
                    int b = (int)data[i, j, 2];
                    bitmap.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            BitmapData sourceData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            bitmap.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = GaussianBlur5x5.GetLength(1);
            int filterHeight = GaussianBlur5x5.GetLength(0);

            // Calculation of Center pixel Offset from the border of the Kernel
            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;
            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < bitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < bitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    // Calculation of Convolution Kernel
                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) * GaussianBlur5x5[filterY + filterOffset, filterX + filterOffset]/159;

                            green += (double)(pixelBuffer[calcOffset + 1]) * GaussianBlur5x5[filterY + filterOffset, filterX + filterOffset]/159;

                            red += (double)(pixelBuffer[calcOffset + 2]) * GaussianBlur5x5[filterY + filterOffset, filterX + filterOffset]/159;
                        }
                    }

                    // Total RGB values for selected pixel
                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    // Set Bytes limits between 0 and 255;
                    blue = (blue > 255 ? 255 : (blue < 0 ? 0 : blue));
                    green = (green > 255 ? 255 : (green < 0 ? 0 : green));
                    red = (red > 255 ? 255 : (red < 0 ? 0 : red));

                    // Set new data in the other byte array for selected image data
                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            //Create new bitmap which will hold the processed data
            Bitmap resultBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            // Lock bits into system memory
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            // Copy from byte array that holds processed data to bitmap and unlock bits from system memory
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
           
            // Convert the image into Array
            int ImageWidth = resultBitmap.Width;
            int ImageHeight = resultBitmap.Height;

            double[,,] ImageArray = new double[ImageWidth, ImageHeight, 3];

            for (int i = 0; i < ImageWidth; i++)
            {
                for (int j = 0; j < ImageHeight; j++)
                {
                    Color color = resultBitmap.GetPixel(i, j);
                    ImageArray[i, j, 0] = color.R;
                    ImageArray[i, j, 1] = color.G;
                    ImageArray[i, j, 2] = color.B;
                }
            }

            return ImageArray;

        }
    }
}
