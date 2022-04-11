using Client.Client;
using Client.Options;
using Microsoft.Extensions.Options;

var client = new RippleAccountClient(new OptionsMonitor<RippleOptions>())