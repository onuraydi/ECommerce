// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServerdotnet
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes = {"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes = {"CommentFullPermission"}},
            new ApiResource("ResourceImage"){Scopes = {"ImageFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes = {"PaymentFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes = {"MessageFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes = {"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for Basket operations"),
            new ApiScope("CommentFullPermission","Full authority for Comment operations"),
            new ApiScope("ImageFullPermission","Full authority for Image operations"),
            new ApiScope("PaymentFullPermission","Full authority for Payment operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("OcelotFullPermission","Full authority for Ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId = "ECommerceVisitorId",
                ClientName = "ECommerce Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("ecommercesecret".Sha256())},
                AllowedScopes = {"CatalogReadPermission", "CatalogFullPermission" ,"DiscountFullPermission", "OcelotFullPermission", "CommentFullPermission", "ImageFullPermission", "PaymentFullPermission" }
            },

            // Manager

            new Client
            {
                ClientId = "ECommerceManagerId",
                ClientName = "ECommerce Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("ecommercesecret".Sha256())},
                AllowedScopes = {"CatalogFullPermission", "CatalogReadPermission", "OrderFullPermission", "CargoFullPermission", "OcelotFullPermission", "CommentFullPermission", "ImageFullPermission", "PaymentFullPermission","BasketFullPermission","DiscountFullPermission","MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
            },

            // Admin

            new Client
            {
                ClientId = "ECommerceAdminId",
                ClientName = "ECommerce Admin User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("ecommercesecret".Sha256())},
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","ImageFullPermission","PaymentFullPermission","MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600
            }
        };
    }
}