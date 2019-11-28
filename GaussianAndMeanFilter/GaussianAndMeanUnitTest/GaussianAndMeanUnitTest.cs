using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningFoundation;
using System.Drawing;
using GaussianAndMeanFilter;
using System;
using System.IO;

namespace GaussianAndMeanUnitTest
{
    [TestClass]
    public class GaussianAndMeanTest
    {

        /// <summary>
        /// Convert the Bitmap image into Array
        /// </summary>
        /// <param name="bitmap">this is the pixel data of the Bitmap image</param>
        /// <returns></returns>
        public static double[,,] ConvertFromBitmapToArray(Bitmap bitmap)
        {
            int ImageWidth = bitmap.Width;
            int ImageHeight = bitmap.Height;
            
            double[,,] ImageArray = new double[ImageWidth, ImageHeight, 3];

            for (int i = 0; i < ImageWidth; i++)
            {
                for (int j = 0; j < ImageHeight; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    ImageArray[i, j, 0] = color.R;
                    ImageArray[i, j, 1] = color.G;
                    ImageArray[i, j, 2] = color.B;
                }
            }

            return ImageArray;
        }

        /// <summary>
        /// Load Method for loading a Bitmap image, which will be converted into double[,,]
        /// </summary>
        /// <param name="filename">this is the filename of the Bitmap image</param>
        /// <returns></returns>
        public static double[,,] Load(string filename)
        {
            Bitmap bitmap = new Bitmap(filename);

            return ConvertFromBitmapToArray(bitmap);
        }

        /// <summary>
        /// First Test Method for Gaussian Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianTest1()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage1.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Gaussian1.jpg");

        }

        /// <summary>
        /// First Test Method for Mean Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Mean Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void MeanTest1()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage1.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseMeanFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Mean1.jpg");

        }

        /// <summary>
        /// First Test Method for Gaussian And Mean Combined Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian And Mean Combined Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianAndMeanCombinedTest1()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage1.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianAndMeanCombined();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Combined1.jpg");

        }

        /// <summary>
        /// Second Test Method for Gaussian Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianTest2()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage2.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Gaussian2.jpg");

        }

        /// <summary>
        /// Second Test Method for Mean Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Mean Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void MeanTest2()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage2.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseMeanFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Mean2.jpg");

        }

        /// <summary>
        /// Second Test Method for Gaussian And Mean Combined Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian And Mean Combined Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianAndMeanCombinedTest2()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage2.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianAndMeanCombined();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Combined2.jpg");

        }

        /// <summary>
        /// Third Test Method for Gaussian Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianTest3()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage3.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Gaussian3.jpg");

        }

        /// <summary>
        /// Third Test Method for Mean Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Mean Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void MeanTest3()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage3.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseMeanFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Mean3.jpg");

        }

        /// <summary>
        /// Third Test Method for Gaussian And Mean Combined Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian And Mean Combined Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianAndMeanCombinedTest3()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage3.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianAndMeanCombined();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Combined3.jpg");

        }
        /// <summary>
        /// Fourth Test Method for Gaussian Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianTest4()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage4.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Gaussian4.jpg");

        }

        /// <summary>
        /// Fourth Test Method for Mean Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Mean Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void MeanTest4()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage4.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseMeanFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Mean4.jpg");

        }

        /// <summary>
        /// Fourth Test Method for Gaussian And Mean Combined Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian And Mean Combined Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianAndMeanCombinedTest4()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage4.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianAndMeanCombined();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Combined4.jpg");

        }
        /// <summary>
        /// Fifth Test Method for Gaussian Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianTest5()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage5.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Gaussian5.jpg");

        }

        /// <summary>
        /// Fifth Test Method for Mean Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Mean Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void MeanTest5()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage5.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseMeanFilter();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Mean5.jpg");

        }

        /// <summary>
        /// Fifth Test Method for Gaussian And Mean Combined Filter
        /// This method is used to Test the Algorithm. Bitmap image will be loaded from TestInputImages folder and converted into double[,,]. After that the Gaussian And Mean Combined Algorithm will be executed.
        /// Then the result image will be converted back to Bitmap and saved in TestOutputImages folder.
        /// </summary>
        [TestMethod]
        public void GaussianAndMeanCombinedTest5()
        {
            LearningApi lApi = new LearningApi();

            lApi.UseActionModule<double[,,], double[,,]>((input, ctx) =>
            {

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(baseDirectory, "TestInputImages\\TestImage5.jpg");
                double[,,] data = Load(path);
                return data;

            });

            lApi.UseGaussianAndMeanCombined();
            double[,,] result = lApi.Run() as double[,,];

            // Convert Array to Bitmap
            Bitmap bitmapresult = new Bitmap(result.GetLength(0), result.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    int r = (int)result[i, j, 0];
                    int g = (int)result[i, j, 1];
                    int b = (int)result[i, j, 2];
                    bitmapresult.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }

            string baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
            string outpath = baseDirectory2 + "\\TestOutputImages\\";

            if (!Directory.Exists(outpath))
            {
                Directory.CreateDirectory(outpath);
            }

            bitmapresult.Save(outpath + "Combined5.jpg");

        }
    }
}
   