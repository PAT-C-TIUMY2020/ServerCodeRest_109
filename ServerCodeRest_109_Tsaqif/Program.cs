using ServerCodeRest_109_Tsaqif.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using ServiceRest_109_Tsaqif;
using System.Text;
using System.Threading.Tasks;
using ITI_UMY = ServiceRest_109_Tsaqif.ITI_UMY;

namespace ServerCodeRest_109_Tsaqif
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObjek = null;
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/ServiceRest_109_Tsaqif/Service1/");
            WebHttpBinding binding = new WebHttpBinding();

            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY), address);
                hostObjek.AddServiceEndpoint(typeof(ITI_UMY), binding, "");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostObjek.Description.Behaviors.Add(smb);
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObjek.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObjek.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObjek.Open();
                Console.WriteLine("Server ready...");
                Console.ReadLine();
                hostObjek.Close();
            }
            catch (Exception ex)
            {
                hostObjek = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
