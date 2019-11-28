using LearningFoundation;

namespace GaussianAndMeanFilter
{

    /// <summary>
    /// Main class for the Gaussain and Mean Filter combined algorithm using IPipeline
    /// </summary>
    public class GaussianAndMeanCombined : IPipelineModule<double[,,], double[,,]>
    {
        /// <summary>
        /// Gaussian Filter Kernel of 3x3
        /// </summary>
        public static double[,] GaussianBlur3x3
        {
            get
            {
                return new double[,]
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
        /// Mean Filter Kernel of 3x3
        /// </summary>
        public static double[,] Mean3x3
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, },
                  { 1, 1, 1, },
                  { 1, 1, 1, }, };
            }
        }
        
        /// <summary>
        /// Mean Filter Kernel of 5x5
        /// </summary>
        public static double[,] Mean5x5
        {
            get
            {
                return new double[,]
                { { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1},
                  { 1, 1, 1, 1, 1}, };
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
            return GaussianAndMeanConvolutionFilter(data, GaussianBlur5x5, Mean5x5, 1, 0);
        }

        /// <summary>
        /// For the combined result of both the filters, first the image is passed to the Gaussian method and then the output image array from Gaussian method is passed to the Mean method.
        /// /// </summary>
        /// <param name="data">data coming from Run method of Ipipeline Interface</param>
        /// <param name="GaussianBlur5x5">the Gaussian Filter Kernel of Matrix 5x5</param>
        /// <param name="Mean5x5">the Mean Filter Kernel of Matrix 5x5</param>
        /// <param name="factor">multiplying factor for adjusting RGB contrast</param>
        /// <param name="bias">addition factor for adjusting RGB contrast</param>
        /// <returns></returns>
        public double[,,] GaussianAndMeanConvolutionFilter(double[,,] data, double[,] GaussianBlur5x5, double[,] Mean5x5, double factor = 1, int bias = 0)
        {
            GaussianFilter gauss = new GaussianFilter();
            MeanFilter mean = new MeanFilter();
            return mean.MeanConvolutionFilter(gauss.GaussianConvolutionFilter(data, GaussianBlur5x5, 1, 0), Mean5x5, 1, 0);
        }       
    }
}
