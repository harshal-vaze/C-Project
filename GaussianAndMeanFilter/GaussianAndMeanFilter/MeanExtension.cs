using LearningFoundation;
using System;

namespace GaussianAndMeanFilter
{

    /// <summary>
    /// Extention Method class as per Learning Api architecture.
    /// </summary>
    public static class MeanExtention
    {

        /// <summary>
        /// Creating Object of MeanFilter in this method and adding it to Api.
        /// </summary>
        /// <param name="api">this is an api used to add module and reference of LearningApi</param>
        /// <returns></returns>
        public static LearningApi UseMeanFilter(this LearningApi api)
        {
            MeanFilter module = new MeanFilter();
            api.AddModule(module, $"Mean-{Guid.NewGuid()}");
            return api;
        }
    }
}
