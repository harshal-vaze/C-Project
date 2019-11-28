using LearningFoundation;
using System;

namespace GaussianAndMeanFilter
{

    /// <summary>
    /// Extention Method class as per Learning Api architecture.
    /// </summary>
    public static class GaussianAndMeanCombinedExtension
    {

        /// <summary>
        /// Creating Object of GaussianAndMeanCombined in this method and adding it to Api.
        /// </summary>
        /// <param name="api">this is an api used to add module and reference of LearningApi</param>
        /// <returns></returns>
        public static LearningApi UseGaussianAndMeanCombined(this LearningApi api)
        {
            GaussianAndMeanCombined module = new GaussianAndMeanCombined();
            api.AddModule(module, $"GaussianAndMeanCombined-{Guid.NewGuid()}");
            return api;
        }
    }
}
