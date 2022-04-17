﻿using Invoice_Manager.Commands;
using Invoice_Manager.Commands.CommandHandlers;
using Invoice_Manager.Helpers;
using Invoice_Manager.Interfaces;
using Invoice_Manager.Mappers;
using Invoice_Manager.Migrations;
using Invoice_Manager.Models;
using Invoice_Manager.Notifications.Handlers;
using Invoice_Manager.Queries;
using Invoice_Manager.Queries.QueryHandler;
using Invoice_Manager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;
namespace Invoice_Manager.Composer
{
    public class InvoiceManagerComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddUnique<CustomerServiceDependencies>();
            builder.AddNotificationHandler<UmbracoApplicationStartingNotification, ExecuteMigration>();
            builder.Services.AddUnique<InvoiceManagerBackOfficeHelperDependencies>();
            builder.AddNotificationHandler<ServerVariablesParsingNotification, ServerVariablesParsingHandler>();
            builder.Services.AddUnique<ICustomerService, CustomerService>();
            builder.Services.AddUnique<ICustomer, Customer>();
            builder.Services.AddUnique<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddUnique<IQueryDispatcher, QueryDispatcher>();
            builder.Services.AddUnique<ICommand,AddCustomerCommand>();
            builder.Services.AddUnique<ICommandHandler<AddCustomerCommand>, AddCustomerCommandHandler>();
            builder.Services.AddUnique<ICommandHandler<EditCustomerCommand>, EditCustomerCommandHandler>();
            builder.Services.AddUnique<IQueryHandler<GetCustomerQuery, SearchResult>, GetCustomerHandler>();
            builder.Services.AddUnique<ICommandHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();
            builder.Services.AddUnique<InvoiceManagerBackOfficeHelper>();
            builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>().Add<CustomerMappingDefinition>();

        }
    }
}
