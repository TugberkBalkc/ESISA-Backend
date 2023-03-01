using ESISA.Core.Application.Utilities.Pipelines.MediatR.Validation.FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions
{
    internal static class PipelineRegistration
    {
        internal static void RegisterMediatRPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
