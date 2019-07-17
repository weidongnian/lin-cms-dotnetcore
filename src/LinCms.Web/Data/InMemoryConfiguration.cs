﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;

namespace LinCms.Web.Data
{
    public static class InMemoryConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                //Configuration["Service:Name"]在AddJwtBearerAudience
                new ApiResource(Configuration["Service:Name"], Configuration["Identity:DocName"])
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // resource owner password grant client
                new Client
                {
                    ClientId = Configuration["Service:ClientId"],
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 3600 * 6, //6小时
                    SlidingRefreshTokenLifetime = 1296000, //15天
                    ClientSecrets =
                    {
                        new Secret(Configuration["Service:ClientSecrets"].Sha256())
                    },
                    AllowedScopes = { Configuration["Service:Name"], IdentityServerConstants.StandardScopes.OfflineAccess}
                }
            };
        }
    }
}