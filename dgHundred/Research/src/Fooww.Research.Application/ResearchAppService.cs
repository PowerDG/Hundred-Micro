using System;
using System.Collections.Generic;
using System.Text;
using Fooww.Research.Localization;
using Volo.Abp.Application.Services;

namespace Fooww.Research
{
    /* Inherit your application services from this class.
     */
    public abstract class ResearchAppService : ApplicationService
    {
        protected ResearchAppService()
        {
            LocalizationResource = typeof(ResearchResource);
        }
    }
}
