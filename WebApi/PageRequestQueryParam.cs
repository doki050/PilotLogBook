﻿using Domain.Exceptions;
using Domain.UseCases.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public class PageRequestQueryParam
{
    [FromQuery] public int? Page { get; set; }

    [FromQuery] public int? Limit { get; set; }

    public PageRequest ToDomainObject()
    {
        return PageRequest.Default with
        {
            Page = Page ?? PageRequest.Default.Page,
            Limit = Limit ?? PageRequest.Default.Limit
        };
    }

    public void ThrowIfInvalid(PageRequestQueryParam param)
    {
        if (param.Page < 1)
            throw new DataValidationException()
                .SetData("page", param.Page);

        if (param.Limit < 1)
            throw new DataValidationException()
                .SetData("limit", param.Limit);
    }
}