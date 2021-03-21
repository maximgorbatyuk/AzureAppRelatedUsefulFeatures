﻿using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Utils.ValueObjects;
using WebHost.Infrastructure.Contracts.MessageBroker;
using WebHost.Infrastructure.Contracts.ServiceBusMessages;

namespace WebHost.Infrastructure.Azure.ServiceBus
{
    // https://gist.github.com/danielhunex/c1cfed093396b6b43ec927c63f3540af
    public class AzureBrokerEmailConsumerBackService : AzureBusTopicConsumerBase
    {
        public AzureBrokerEmailConsumerBackService(
            ILogger<AzureBrokerEmailConsumerBackService> logger,
            IServiceScopeFactory scopeFactory,
            MessageBrokerSettings brokerSettings)
            : base(
                logger,
                scopeFactory,
                brokerSettings)
        {
        }

        // handle received messages
        protected override NonNullableString MessageTopic => BrokerSettings.EmailMessageTopic;

        protected override Task MessageHandleInternalAsync(IServiceProvider provider, ServiceBusReceivedMessage message)
        {
            string body = message.Body.ToString();
            var email = provider.GetRequiredService<IEmail>();
            return email.SendAsync(body);
        }
    }
}