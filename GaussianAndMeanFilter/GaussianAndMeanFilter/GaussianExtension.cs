using LearningFoundation;
using System;

namespace GaussianAndMeanFilter
{

    /// <summary>
    /// Extention Method class as per Learning Api architecture.
    /// </summary>
    public static class GaussianExtension
    {

        /// <summary>
        /// Creating Object of GaussianFilter in this method and adding it to Api.
        /// </summary>
        /// <param name="api">this is an api used to add module and reference of LearningApi</param>
        /// <returns></returns>
        public static LearningApi UseGaussianFilter(this LearningApi api)
        {
            GaussianFilter module = new GaussianFilter();
            api.AddModule(module, $"Gaussian-{Guid.NewGuid()}");
            return api;
        }
    }
}
