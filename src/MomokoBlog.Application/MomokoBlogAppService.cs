using System;
using System.Collections.Generic;
using System.Text;
using MomokoBlog.Localization;
using Volo.Abp.Application.Services;

namespace MomokoBlog;

/* Inherit your application services from this class.
 */
public abstract class MomokoBlogAppService : ApplicationService
{
    protected MomokoBlogAppService()
    {
        LocalizationResource = typeof(MomokoBlogResource);
    }
}
