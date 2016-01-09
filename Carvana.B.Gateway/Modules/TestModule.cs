using Nancy;

namespace Carvana.B.Gateway.Modules
{
    public class TestModule : NancyModule
    {
        public TestModule() : base("/test")
        {
            Get["/"] = parameterss => "Hello From B";
        }
    }
}
