﻿using ESISA.Core.Application.Utilities.Pipelines.MediatR.Security.Authorization;
using ESISA.Core.Application.Utilities.Pipelines.MediatR.Transaction;
using ESISA.Core.Application.Utilities.Pipelines.MediatR.Validation.FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.DIRegitrations
{
    internal static class PipelineRegistration
    {
        internal static void RegisterMediatRPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
