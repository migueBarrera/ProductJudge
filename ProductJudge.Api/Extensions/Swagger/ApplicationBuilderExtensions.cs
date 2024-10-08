﻿using Microsoft.AspNetCore.Builder;

namespace ProductJudge.Api.Extensions.Swagger;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
    {
        return app.UseSwagger()
                  .UseSwaggerUI(c =>
                  {
                      c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductJudge Api V1");
                  });
    }
}
