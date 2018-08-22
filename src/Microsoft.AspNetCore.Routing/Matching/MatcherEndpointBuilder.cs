﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Microsoft.AspNetCore.Routing.Matching
{
    public sealed class MatcherEndpointBuilder : EndpointBuilder
    {
        public RequestDelegate RequestDelegate { get; set; }

        public RoutePattern RoutePattern { get; set; }

        public int Order { get; set; }

        public MatcherEndpointBuilder(
           RequestDelegate requestDelegate,
           RoutePattern routePattern,
           int order)
        {
            RequestDelegate = requestDelegate;
            RoutePattern = routePattern;
            Order = order;
        }

        public override Endpoint Build()
        {
            var matcherEndpoint = new RouteEndpoint(
                RequestDelegate,
                RoutePattern,
                Order,
                new EndpointMetadataCollection(Metadata),
                DisplayName);

            return matcherEndpoint;
        }
    }
}
