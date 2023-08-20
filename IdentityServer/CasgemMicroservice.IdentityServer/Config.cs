﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CasgemMicroservice.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
          {
                new ApiResource("resource_catalog") {Scopes = {"catalog_fullpermission"}},
                    new ApiResource("resource_photostock") {Scopes = {"photostock_fullpermission"}},
                        new ApiResource("resource_basket") {Scopes = {"basket_fullpermission"}},
                            new ApiResource("resource_discount") {Scopes = {"discount_fullpermission"}},
                                 new ApiResource("resource_order") {Scopes = {"order_fullpermission"}},
                                         new ApiResource("resource_cargo") {Scopes = {"cargo_fullpermission"}},
                                              new ApiResource("resource_payment") {Scopes = {"payment_fullpermission"}},
                                                  new ApiResource("resource_gateway") {Scopes = {"gateway_fullpermission"}},

                                                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

          };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                 new ApiScope("catalog_fullpermission","Ürün listesi için full erişim"),
                    new ApiScope("photostock_fullpermission","Fotoğraf işlemleri için full erişim"),
                        new ApiScope("basket_fullpermission","Sepet işlemleri için full erişim"),
                            new ApiScope("discount_fullpermission","İndirim işlemleri için full erişim"),
                                new ApiScope("order_fullpermission","Şipariş işlemleri için full erişim"),
                                    new ApiScope("cargo_fullpermission","Kargo işlemleri için full erişim"),
                                    new ApiScope("payment_fullpermission","Ödeme işlemleri için full erişim"),
                                    new ApiScope("gateway_fullpermission","Gateway işlemleri için full erişim"),
                  new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    //kullanıcı yetkisi
                   ClientId="Casgem1Client",
                   ClientName="Casgem Client Name",
                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                   ClientSecrets={new Secret("secret".Sha256())},
                   AllowedScopes={ 
                        "catalog_fullpermission", 
                        "photostock_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName 
                    }

                },

                // interactive client using code flow + pkce
                new Client
                {
                    //admin yetkisi
                   ClientId="Casgem2Client",
                   ClientSecrets={new Secret("secret".Sha256())},
                   ClientName="Casgem 2 Client Name",
                   AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                   AllowOfflineAccess = true,
                    AllowedScopes=
                    {
                        "catalog_fullpermission", 
                        "basket_fullpermission",
						"photostock_fullpermission",
						"discount_fullpermission",
						"order_fullpermission",
						"cargo_fullpermission",
						"payment_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                      
                   },
                   AccessTokenLifetime=3600
                },
            };
    }
}