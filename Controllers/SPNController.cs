using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPN;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BanqSoft.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class SPNController : ControllerBase
  {

    [HttpGet]
    public string Get()
    {

      WSHttpBinding basicBinding = new WSHttpBinding();
      basicBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
      basicBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
      basicBinding.Name = "WSHttpBinding_iCloudCollect";
      basicBinding.MaxReceivedMessageSize = 524288;
      basicBinding.ReceiveTimeout = new TimeSpan(0, 20, 0);


      EndpointAddress endpointAddress = new EndpointAddress(new Uri("https://131109.web-site.no/CloudCollect/CloudCollect.svc"));
      // EndpointAddress endpointAddress = new EndpointAddress(new Uri("https://131109.web-site.no/CloudCollectTest/CloudCollect.svc?wsdl"));

      iCloudCollectClient spn = new iCloudCollectClient(basicBinding, endpointAddress);



      // legg til brukernavn/passord for api her
      spn.ClientCredentials.UserName.UserName = "";
      spn.ClientCredentials.UserName.Password = "";

      string x = "test";
      // Legg til brukernavn passord her kreditor her 
      x = spn.PingAsync("ping", "", "", "000462").Result;
      Console.WriteLine(spn);

      return x;
    }
  }
}
