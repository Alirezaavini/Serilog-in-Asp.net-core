
using Serilog;
using System;

namespace Test
{
    public static class Class1
    {
        
        public static void testException()
        {
            try
            {
                throw new Exception();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex,"test error");
            }
        }
    }
}
