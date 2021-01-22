using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAPIWebMotors.Page
{
    public class APIPage
    {        
            public class Rootobject
            {
                public WebMotors[] Property1 { get; set; }
            }
            public class WebMotors
            {
                public string Model { get; set; }
                public string Make { get; set; }
                public int ID { get; set; }
                public string Name { get; set; }
                public string Version { get; set; }
        }        
    }
    
}
